﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DevCDRAgent.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.3.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://devcdrcore.azurewebsites.net/chat")]
        public string Endpoint {
            get {
                return ((string)(this["Endpoint"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\r\nfunction OS\r\n{\r\n\tGet-CimInstance Win32_OperatingSystem\r\n}\r\n\r\n\r\nfunction RebootP" +
            "ending\r\n{\r\n\t$FileRenamePending = $false;\r\n\t$ComponentRebootPending = if(test-pat" +
            "h \"HKLM:\\SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Component Based Servicing\\Reb" +
            "ootPending\"){ $true } else { $false }\r\n\ttry { if(@(((Get-ItemProperty(\"HKLM:\\SYS" +
            "TEM\\CurrentControlSet\\Control\\Session Manager\")).$(\"PendingFileRenameOperations\"" +
            ")) | Where-Object { $_ }).length -ne 0) { $FileRenamePending = $true }; } catch{" +
            "}\r\n\tif($FileRenamePending -or $ComponentRebootPending) { return $true };\r\n\tretur" +
            "n $false;\r\n}\r\n\r\n\r\nfunction UsersOnline\r\n{\r\n\t$proc = @(Get-WmiObject win32_proces" +
            "s -Filter \"Name = \'explorer.exe\'\");\r\n\tif($proc.Length -gt 0) { return $true } el" +
            "se { return $false };\r\n}\r\n\r\nfunction GetMyID {\r\n    $object = New-Object -TypeNa" +
            "me PSObject\r\n    $object | Add-Member -MemberType NoteProperty -Name \"Domain\" -V" +
            "alue ((get-wmiobject -ClassName \"win32_ComputerSystem\").Domain)\r\n    $object | A" +
            "dd-Member -MemberType NoteProperty -Name \"#Name\" -Value ($env:computername) \r\n  " +
            "  $object | Add-Member -MemberType NoteProperty -Name \"#UUID\" -Value ((get-wmiob" +
            "ject -ClassName \"win32_ComputerSystemProduct\").UUID)\r\n    return GetHash($object" +
            " | ConvertTo-Json -Compress)\r\n}\r\n\r\nfunction GetHash([string]$txt) {\r\n    return " +
            "GetMD5($txt)\r\n}\r\n\r\nfunction GetMD5([string]$txt) {\r\n    $md5 = new-object -TypeN" +
            "ame System.Security.Cryptography.MD5CryptoServiceProvider\r\n    $utf8 = new-objec" +
            "t -TypeName System.Text.ASCIIEncoding\r\n    return Base58(@(0xd5, 0x10) + $md5.Co" +
            "mputeHash($utf8.GetBytes($txt))) #To store hash in Miltihash format, we add a 0x" +
            "D5 to make it an MD5 and an 0x10 means 10Bytes length\r\n}\r\n\r\nfunction GetSHA2_256" +
            "([string]$txt) {\r\n    $sha = new-object -TypeName System.Security.Cryptography.S" +
            "HA256CryptoServiceProvider\r\n    $utf8 = new-object -TypeName System.Text.ASCIIEn" +
            "coding\r\n    return Base58(@(0x12, 0x20) + $sha.ComputeHash($utf8.GetBytes($txt))" +
            ") #To store hash in Miltihash format, we add a 0x12 to make it an SHA256 and an " +
            "0x20 means 32Bytes length\r\n}\r\n\r\nfunction Base58([byte[]]$data) {\r\n    $Digits = " +
            "\"123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz\"\r\n    [bigint]$intDa" +
            "ta = 0\r\n    for ($i = 0; $i -lt $data.Length; $i++) {\r\n        $intData = ($intD" +
            "ata * 256) + $data[$i]; \r\n    }\r\n    [string]$result = \"\";\r\n    while ($intData " +
            "-gt 0) {\r\n        $remainder = ($intData % 58);\r\n        $intData /= 58;\r\n      " +
            "  $result = $Digits[$remainder] + $result;\r\n    }\r\n\r\n    for ($i = 0; ($i -lt $d" +
            "ata.Length) -and ($data[$i] -eq 0); $i++) {\r\n        $result = \'1\' + $result;\r\n " +
            "   }\r\n\r\n    return $result\r\n}\r\n\r\n$OS = (OS)\r\n$UBR = (Get-ItemProperty \'HKLM:\\SOF" +
            "TWARE\\Microsoft\\Windows NT\\CurrentVersion\' -Name UBR).UBR\r\n$object = New-Object " +
            "-TypeName PSObject\r\n$object | Add-Member -MemberType NoteProperty -Name \"Hostnam" +
            "e\" -Value (hostname).ToUpper()\r\n$object | Add-Member -MemberType NoteProperty -N" +
            "ame \"id\" -Value (GetMyID)\r\n$object | Add-Member -MemberType NoteProperty -Name \"" +
            "Internal IP\" -Value ((Test-Connection (hostname) -Count 1).IPV4Address.IPAddress" +
            "ToString)\r\n$object | Add-Member -MemberType NoteProperty -Name \"Last Reboot\" -Va" +
            "lue $OS.LastBootUpTime\r\n$object | Add-Member -MemberType NoteProperty -Name \"Reb" +
            "oot Pending\" -Value (RebootPending)\r\n$object | Add-Member -MemberType NoteProper" +
            "ty -Name \"Users Online\" -Value (UsersOnline)\r\n$object | Add-Member -MemberType N" +
            "oteProperty -Name \"OS\" -Value $OS.Caption\r\n$object | Add-Member -MemberType Note" +
            "Property -Name \"Version\" -Value ($OS.Version + \'.\' + $UBR)\r\n$object | Add-Member" +
            " -MemberType NoteProperty -Name \"Arch\" -Value $OS.OSArchitecture\r\n$object | Add-" +
            "Member -MemberType NoteProperty -Name \"Lang\" -Value $OS.OSLanguage\r\n$object | Ad" +
            "d-Member -MemberType NoteProperty -Name \"User\" -Value (Get-Item HKLM:SYSTEM\\Curr" +
            "entControlSet\\Control\\CloudDomainJoin\\JoinInfo\\* -ea SilentlyContinue | Get-Item" +
            "Property).UserEmail\r\n$object | ConvertTo-Json\r\n# SIG # Begin signature block\r\n# " +
            "MIIOEgYJKoZIhvcNAQcCoIIOAzCCDf8CAQExCzAJBgUrDgMCGgUAMGkGCisGAQQB\r\n# gjcCAQSgWzBZ" +
            "MDQGCisGAQQBgjcCAR4wJgIDAQAABBAfzDtgWUsITrck0sYpfvNR\r\n# AgEAAgEAAgEAAgEAAgEAMCEw" +
            "CQYFKw4DAhoFAAQUmDv3ITcblKJ01dRsYHBIPOdv\r\n# FHmgggtIMIIFYDCCBEigAwIBAgIRANsn6eS1" +
            "hYK93tsNS/iNfzcwDQYJKoZIhvcN\r\n# AQELBQAwfTELMAkGA1UEBhMCR0IxGzAZBgNVBAgTEkdyZWF0" +
            "ZXIgTWFuY2hlc3Rl\r\n# cjEQMA4GA1UEBxMHU2FsZm9yZDEaMBgGA1UEChMRQ09NT0RPIENBIExpbWl0" +
            "ZWQx\r\n# IzAhBgNVBAMTGkNPTU9ETyBSU0EgQ29kZSBTaWduaW5nIENBMB4XDTE4MDUyMjAw\r\n# MDAw" +
            "MFoXDTIxMDUyMTIzNTk1OVowgawxCzAJBgNVBAYTAkNIMQ0wCwYDVQQRDAQ4\r\n# NDgzMQswCQYDVQQI" +
            "DAJaSDESMBAGA1UEBwwJS29sbGJydW5uMRkwFwYDVQQJDBBI\r\n# YWxkZW5zdHJhc3NlIDMxMQ0wCwYD" +
            "VQQSDAQ4NDgzMRUwEwYDVQQKDAxSb2dlciBa\r\n# YW5kZXIxFTATBgNVBAsMDFphbmRlciBUb29sczEV" +
            "MBMGA1UEAwwMUm9nZXIgWmFu\r\n# ZGVyMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA1ujn" +
            "ILmAULVtVv3b\r\n# /CDpM6RCdLV9Zjg+CDJFWLBzzjwAcHueV0mv4YgF4WoOhuc3o7GcIvl3P1DqxW97" +
            "\r\n# ex8cCfFcqdObZszKpP9OyeU5ft4c/rmfPC6PD2sKEWIIvLHAw/RXFS4RFoHngyGo\r\n# 4070NFEM" +
            "fFdQOSvBwHodsa128FG8hThRn8lXlWJG3327o39kLfawFAaCtfqEBVDd\r\n# k4lYLl2aRpvuobfEATZ0" +
            "16qAHhxkExtuI007gGH58aokxpX+QWJI6T/Bj5eBO4Lt\r\n# IqS6JjJdkRZPNc4Pa98OA+91nxoY5uZd" +
            "rCrKReDeZ8qNZcyobgqAaCLtBS2esDFN\r\n# 8HMByQIDAQABo4IBqTCCAaUwHwYDVR0jBBgwFoAUKZFg" +
            "/4pN+uv5pmq4z/nmS71J\r\n# zhIwHQYDVR0OBBYEFE+rkhTxw3ewJzXsZWbrdnRwy7y0MA4GA1UdDwEB" +
            "/wQEAwIH\r\n# gDAMBgNVHRMBAf8EAjAAMBMGA1UdJQQMMAoGCCsGAQUFBwMDMBEGCWCGSAGG+EIB\r\n# " +
            "AQQEAwIEEDBGBgNVHSAEPzA9MDsGDCsGAQQBsjEBAgEDAjArMCkGCCsGAQUFBwIB\r\n# Fh1odHRwczov" +
            "L3NlY3VyZS5jb21vZG8ubmV0L0NQUzBDBgNVHR8EPDA6MDigNqA0\r\n# hjJodHRwOi8vY3JsLmNvbW9k" +
            "b2NhLmNvbS9DT01PRE9SU0FDb2RlU2lnbmluZ0NB\r\n# LmNybDB0BggrBgEFBQcBAQRoMGYwPgYIKwYB" +
            "BQUHMAKGMmh0dHA6Ly9jcnQuY29t\r\n# b2RvY2EuY29tL0NPTU9ET1JTQUNvZGVTaWduaW5nQ0EuY3J0" +
            "MCQGCCsGAQUFBzAB\r\n# hhhodHRwOi8vb2NzcC5jb21vZG9jYS5jb20wGgYDVR0RBBMwEYEPcm9nZXJA" +
            "emFu\r\n# ZGVyLmNoMA0GCSqGSIb3DQEBCwUAA4IBAQBHs/5P4BiQqAuF83Z4R0fFn7W4lvfE\r\n# 6KJO" +
            "KpXajK+Fok+I1bDl1pVC9JIqhdMt3tdOFwvSl0/qQ9Sp2cZnMovaxT8Bhc7s\r\n# +PDbzRlklGGRlnVg" +
            "6i7RHnJ90bRdxPTFUBbEMLy7UAjQ4iPPfRoxaR4rzF3BLaaz\r\n# b7BoGc/oEPIMo/WmXWFngeHAVQ6g" +
            "Vlr2WXrKwHo8UlN0jmgzR7QrD3ZHbhR4yRNq\r\n# M97TgVp8Fdw3o+PnwMRj4RIeFiIr9KGockQWqth+" +
            "W9CDRlTgnxE8MhKl1PbUGUFM\r\n# DcG3cV+dFTI8P2/sYD+aQHdBr0nDT2RWSgeEchQ1s/isFwOVBrYE" +
            "qqf7MIIF4DCC\r\n# A8igAwIBAgIQLnyHzA6TSlL+lP0ct800rzANBgkqhkiG9w0BAQwFADCBhTELMAkG" +
            "\r\n# A1UEBhMCR0IxGzAZBgNVBAgTEkdyZWF0ZXIgTWFuY2hlc3RlcjEQMA4GA1UEBxMH\r\n# U2FsZm9y" +
            "ZDEaMBgGA1UEChMRQ09NT0RPIENBIExpbWl0ZWQxKzApBgNVBAMTIkNP\r\n# TU9ETyBSU0EgQ2VydGlm" +
            "aWNhdGlvbiBBdXRob3JpdHkwHhcNMTMwNTA5MDAwMDAw\r\n# WhcNMjgwNTA4MjM1OTU5WjB9MQswCQYD" +
            "VQQGEwJHQjEbMBkGA1UECBMSR3JlYXRl\r\n# ciBNYW5jaGVzdGVyMRAwDgYDVQQHEwdTYWxmb3JkMRow" +
            "GAYDVQQKExFDT01PRE8g\r\n# Q0EgTGltaXRlZDEjMCEGA1UEAxMaQ09NT0RPIFJTQSBDb2RlIFNpZ25p" +
            "bmcgQ0Ew\r\n# ggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCmmJBjd5E0f4rR3elnMRHr\r\n# " +
            "zB79MR2zuWJXP5O8W+OfHiQyESdrvFGRp8+eniWzX4GoGA8dHiAwDvthe4YJs+P9\r\n# omidHCydv3Lj" +
            "5HWg5TUjjsmK7hoMZMfYQqF7tVIDSzqwjiNLS2PgIpQ3e9V5kAoU\r\n# GFEs5v7BEvAcP2FhCoyi3PbD" +
            "MKrNKBh1SMF5WgjNu4xVjPfUdpA6M0ZQc5hc9IVK\r\n# aw+A3V7Wvf2pL8Al9fl4141fEMJEVTyQPDFG" +
            "y3CuB6kK46/BAW+QGiPiXzjbxghd\r\n# R7ODQfAuADcUuRKqeZJSzYcPe9hiKaR+ML0btYxytEjy4+gh" +
            "+V5MYnmLAgaff9UL\r\n# AgMBAAGjggFRMIIBTTAfBgNVHSMEGDAWgBS7r34CPfqm8TyEjq3uOJjs2TIy" +
            "1DAd\r\n# BgNVHQ4EFgQUKZFg/4pN+uv5pmq4z/nmS71JzhIwDgYDVR0PAQH/BAQDAgGGMBIG\r\n# A1Ud" +
            "EwEB/wQIMAYBAf8CAQAwEwYDVR0lBAwwCgYIKwYBBQUHAwMwEQYDVR0gBAow\r\n# CDAGBgRVHSAAMEwG" +
            "A1UdHwRFMEMwQaA/oD2GO2h0dHA6Ly9jcmwuY29tb2RvY2Eu\r\n# Y29tL0NPTU9ET1JTQUNlcnRpZmlj" +
            "YXRpb25BdXRob3JpdHkuY3JsMHEGCCsGAQUF\r\n# BwEBBGUwYzA7BggrBgEFBQcwAoYvaHR0cDovL2Ny" +
            "dC5jb21vZG9jYS5jb20vQ09N\r\n# T0RPUlNBQWRkVHJ1c3RDQS5jcnQwJAYIKwYBBQUHMAGGGGh0dHA6" +
            "Ly9vY3NwLmNv\r\n# bW9kb2NhLmNvbTANBgkqhkiG9w0BAQwFAAOCAgEAAj8COcPu+Mo7id4MbU2x8U6S" +
            "\r\n# T6/COCwEzMVjEasJY6+rotcCP8xvGcM91hoIlP8l2KmIpysQGuCbsQciGlEcOtTh\r\n# 6Qm/5iR0" +
            "rx57FjFuI+9UUS1SAuJ1CAVM8bdR4VEAxof2bO4QRHZXavHfWGshqknU\r\n# fDdOvf+2dVRAGDZXZxHN" +
            "TwLk/vPa/HUX2+y392UJI0kfQ1eD6n4gd2HITfK7ZU2o\r\n# 94VFB696aSdlkClAi997OlE5jKgfcHmt" +
            "bUIgos8MbAOMTM1zB5TnWo46BLqioXwf\r\n# y2M6FafUFRunUkcyqfS/ZEfRqh9TTjIwc8Jvt3iCnVz/" +
            "RrtrIh2IC/gbqjSm/Iz1\r\n# 3X9ljIwxVzHQNuxHoc/Li6jvHBhYxQZ3ykubUa9MCEp6j+KjUuKOjswm" +
            "5LLY5TjC\r\n# qO3GgZw1a6lYYUoKl7RLQrZVnb6Z53BtWfhtKgx/GWBfDJqIbDCsUgmQFhv/K53b\r\n# " +
            "0CDKieoofjKOGd97SDMe12X4rsn4gxSTdn1k0I7OvjV9/3IxTZ+evR5sL6iPDAZQ\r\n# +4wns3bJ9ObX" +
            "wzTijIchhmH+v1V04SF3AwpobLvkyanmz1kl63zsRQ55ZmjoIs24\r\n# 75iFTZYRPAmK0H+8KCgT+2rK" +
            "VI2SXM3CZZgGns5IW9S1N5NGQXwH3c/6Q++6Z2H/\r\n# fUnguzB9XIDj5hY5S6cxggI0MIICMAIBATCB" +
            "kjB9MQswCQYDVQQGEwJHQjEbMBkG\r\n# A1UECBMSR3JlYXRlciBNYW5jaGVzdGVyMRAwDgYDVQQHEwdT" +
            "YWxmb3JkMRowGAYD\r\n# VQQKExFDT01PRE8gQ0EgTGltaXRlZDEjMCEGA1UEAxMaQ09NT0RPIFJTQSBD" +
            "b2Rl\r\n# IFNpZ25pbmcgQ0ECEQDbJ+nktYWCvd7bDUv4jX83MAkGBSsOAwIaBQCgeDAYBgor\r\n# BgEE" +
            "AYI3AgEMMQowCKACgAChAoAAMBkGCSqGSIb3DQEJAzEMBgorBgEEAYI3AgEE\r\n# MBwGCisGAQQBgjcC" +
            "AQsxDjAMBgorBgEEAYI3AgEVMCMGCSqGSIb3DQEJBDEWBBQJ\r\n# El4ETitv3UVMbn6i9NzdpesjmDAN" +
            "BgkqhkiG9w0BAQEFAASCAQBZP3Lt9Uza5HeL\r\n# 92i7pAKXjbiCtwn6JwxudoYNGrjea3qjtb2F1d4m" +
            "8034YTqESHvRJ2ezQtdMozI2\r\n# Sc7ovKoFxjizqsYmSiLgCHT6u9nL3KoYQp5Pg5gnfWAWiQvmYGK8" +
            "ZPy6bSI6D+cg\r\n# mf24F0dAPalm1p+itwLJHlpx4l6E179y208pb/gLNVTEUwfO4HaNpxIKNq6SDNo3" +
            "\r\n# Fi4An59H5G0H5cu7VFJ7XQjr/IRHrK7XH6xH1MDO1mzyd03YT745/P3DoiVRnbM8\r\n# 9IEoJ60W" +
            "mhf7ueeGRgUg/NXO9Y5oFuRHjBvWLj5E+bgEZHWOpBJA8J/fZIJOqz6p\r\n# vAEoyWlM\r\n# SIG # En" +
            "d signature block")]
        public string PSStatus {
            get {
                return ((string)(this["PSStatus"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("unknown")]
        public string Groups {
            get {
                return ((string)(this["Groups"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("5000")]
        public int StatusDelay {
            get {
                return ((int)(this["StatusDelay"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public int HealtchCheckMinutes {
            get {
                return ((int)(this["HealtchCheckMinutes"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2018-10-01")]
        public global::System.DateTime HealthCheckSuccess {
            get {
                return ((global::System.DateTime)(this["HealthCheckSuccess"]));
            }
            set {
                this["HealthCheckSuccess"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2018-10-01")]
        public global::System.DateTime InventorySuccess {
            get {
                return ((global::System.DateTime)(this["InventorySuccess"]));
            }
            set {
                this["InventorySuccess"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("12")]
        public int InventoryCheckHours {
            get {
                return ((int)(this["InventoryCheckHours"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2018-10-01")]
        public global::System.DateTime LastConnection {
            get {
                return ((global::System.DateTime)(this["LastConnection"]));
            }
            set {
                this["LastConnection"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int ConnectionErrors {
            get {
                return ((int)(this["ConnectionErrors"]));
            }
            set {
                this["ConnectionErrors"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("https://devcdrcore.azurewebsites.net/chat")]
        public string FallbackEndpoint {
            get {
                return ((string)(this["FallbackEndpoint"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string AgentSignature {
            get {
                return ((string)(this["AgentSignature"]));
            }
            set {
                this["AgentSignature"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string HardwareID {
            get {
                return ((string)(this["HardwareID"]));
            }
            set {
                this["HardwareID"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DEMO")]
        public string CustomerID {
            get {
                return ((string)(this["CustomerID"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("DeviceCommander")]
        public string RootCA {
            get {
                return ((string)(this["RootCA"]));
            }
        }
    }
}
