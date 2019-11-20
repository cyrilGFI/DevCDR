﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DevCDRAgent.Modules
{
    public class SignatureVerification
    {
        public static string CreateSignature(string message, string certSubject)
        {
            try
            {
                var sout = Sign(message, certSubject);

                //create JSON
                JObject jObj = new JObject();
                jObj.Add(new JProperty("MSG", message));
                jObj.Add(new JProperty("SIG", sout));
                jObj.Add(new JProperty("CER", GetPublicCert(certSubject)));

                //create Base64 string
                return Convert.ToBase64String(Encoding.Default.GetBytes(jObj.ToString(Newtonsoft.Json.Formatting.None)));
            }
            catch(Exception ex)
            {

            }

            return "";
        }

        public static bool VerifySignature(string base64signature, string rootSubject, string rootCERFile = "")
        {
            JObject jObj = JObject.Parse(Encoding.Default.GetString(Convert.FromBase64String(base64signature)));
            return Verify(jObj["MSG"].Value<string>(), jObj["SIG"].Value<string>(), jObj["CER"].Value<string>(), rootSubject, rootCERFile);
        }

        internal static string getIssuingCA(X509Certificate2 cert)
        {
            string IssuingCA = "";
            try
            {
                X509Chain ch = new X509Chain(true);
                ch.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
                bool bChain = ch.Build(cert);
                if (bChain)
                {
                    IssuingCA = ch.ChainElements[1].Certificate.Subject.Split('=')[1];
                }
            }
            catch { }
            return IssuingCA;
        }

        internal static string getIssuingCA(string signature)
        {
            JObject jObj = JObject.Parse(Encoding.Default.GetString(Convert.FromBase64String(signature)));
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(jObj["CER"].Value<string>()));
            return getIssuingCA(cert);
        }

        internal static string findIssuingCA(string rootSubjectName)
        {
            try
            {
                X509Store my = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
                my.Open(OpenFlags.ReadOnly);

                // Find the certificate we'll use to sign
                foreach (X509Certificate2 cert in my.Certificates.Find(X509FindType.FindByIssuerName, rootSubjectName, true))
                {
                    if (cert.Subject != cert.Issuer)
                    {
                        return cert.Subject.Split('=')[1];
                        //return Convert.ToBase64String(StringToByteArray(cert.Thumbprint));
                    }
                }
            }
            catch { }

            return "";

        }

        internal static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private static string Sign(string text, string certSubject)
        {
            // Access Personal (MY) certificate store of current user
            X509Store my = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            my.Open(OpenFlags.ReadOnly);

            // Find the certificate we'll use to sign
            foreach (X509Certificate2 cert in my.Certificates.Find(X509FindType.FindBySubjectName, certSubject, true))
            {
                if (cert.GetKeyAlgorithm() == "1.2.840.10045.2.1") //ECDsa Key
                {
                    using (ECDsa key = cert.GetECDsaPrivateKey())
                    {
                        if (key == null)
                        {
                            throw new Exception("No valid cert was found");
                        }

                        return Convert.ToBase64String(key.SignData(Encoding.Default.GetBytes(text), HashAlgorithmName.SHA256));
                    }
                }
                else
                {
                    using (RSA key = cert.GetRSAPrivateKey())
                    {
                        if (key == null)
                        {
                            throw new Exception("No valid cert was found");
                        }

                        return Convert.ToBase64String(key.SignData(Encoding.Default.GetBytes(text), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
                    }
                }
            }

            throw new Exception("No valid cert was found");
        }

        private static string GetPublicCert(string certSubject)
        {
            // Access Personal (MY) certificate store of current user
            X509Store my = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            my.Open(OpenFlags.ReadOnly);

            // Find the certificate we'll use to sign
            foreach (X509Certificate2 cert in my.Certificates.Find(X509FindType.FindBySubjectName, certSubject, true))
            {
                return Convert.ToBase64String(cert.Export(X509ContentType.Cert));
            }

            throw new Exception("No valid cert was found");
        }

        internal static X509Certificate2 GetRootCert(string certSubject, string filePath = "")
        {
            if (string.IsNullOrEmpty(filePath))
            {
                // Access Personal (MY) certificate store of current user
                X509Store my = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
                my.Open(OpenFlags.ReadOnly);

                // Find the certificate we'll use to sign
                foreach (X509Certificate2 cert in my.Certificates.Find(X509FindType.FindBySubjectName, certSubject, true))
                {
                    return cert;
                }
            }

            if (File.Exists(filePath))
            {
                return new X509Certificate2(filePath);
            }

            throw new Exception("No valid cert was found");
        }

        internal static bool Verify(string text, string signature, string base64cert, string rootSubject, string rootCERFile = "")
        {
            X509Certificate2 cert = new X509Certificate2(Convert.FromBase64String(base64cert));

            //Output chain information of the selected certificate.
            X509Chain ch = new X509Chain(true);
            ch.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
            //ch.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
            //ch.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;
            bool bChain = ch.Build(cert);
            if (bChain)
            {
                X509Certificate2 validRootCertificate = GetRootCert(rootSubject, rootCERFile);
                foreach (X509ChainElement element in ch.ChainElements)
                {
                    // Check that the root certificate matches
                    if (Convert.ToBase64String(validRootCertificate.RawData) == Convert.ToBase64String(element.Certificate.RawData))
                    {
                        if (cert.GetKeyAlgorithm() == "1.2.840.10045.2.1") //ECDsa Key
                        {
                            using (ECDsa key = cert.GetECDsaPublicKey())
                            {
                                return key.VerifyData(Encoding.Default.GetBytes(text), Convert.FromBase64String(signature), HashAlgorithmName.SHA256);
                            }
                        }
                        else
                        {
                            using (RSA key = cert.GetRSAPublicKey())
                            {
                                return key.VerifyData(Encoding.Default.GetBytes(text), Convert.FromBase64String(signature), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
                            }
                        }
                    }


                }
            }

            return false;
        }

        internal static bool addCertToStore(System.Security.Cryptography.X509Certificates.X509Certificate2 cert, System.Security.Cryptography.X509Certificates.StoreName st, System.Security.Cryptography.X509Certificates.StoreLocation sl)
        {
            bool bRet = false;

            try
            {
                X509Store store = new X509Store(st, sl);
                store.Open(OpenFlags.ReadWrite);
                var certs = store.Certificates.Find(X509FindType.FindBySubjectDistinguishedName, cert.SubjectName.Name, false);
                
                //Remove existing Certificates
                foreach(X509Certificate2 cer in certs)
                {
                    store.Remove(cer);
                }

                store.Add(cert);

                store.Close();
            }
            catch
            {

            }

            return bRet;
        }

    }
}
