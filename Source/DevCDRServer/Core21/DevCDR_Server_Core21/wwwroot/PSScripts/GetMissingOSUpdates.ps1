﻿#Check if PSWindowsUpdate Module is installed
try {
if(Get-InstalledModule -Name PSWindowsUpdate -MinimumVersion "2.0.0.4" -ea SilentlyContinue) {} else 
{
 Install-PackageProvider -Name NuGet -MinimumVersion 2.8.5.201 -Force
 Set-PSRepository -Name PSGallery -InstallationPolicy Trusted 
 Install-Module PSWindowsUpdate -Force
 (Add-WUServiceManager -ServiceID 7971f918-a847-4430-9279-4a52d1efe18d -confirm:$false).Name
}
}catch { "Error, unable to detect updates" }
$upd = Get-WUList -MicrosoftUpdate
if($upd.count -gt 0) {
 $upd | select Title | ConvertTo-Json
} else { "No missing updates detected."}


# SIG # Begin signature block
# MIIOEgYJKoZIhvcNAQcCoIIOAzCCDf8CAQExCzAJBgUrDgMCGgUAMGkGCisGAQQB
# gjcCAQSgWzBZMDQGCisGAQQBgjcCAR4wJgIDAQAABBAfzDtgWUsITrck0sYpfvNR
# AgEAAgEAAgEAAgEAAgEAMCEwCQYFKw4DAhoFAAQUNO+SME3cxDD6YENX7e8gexnA
# kvSgggtIMIIFYDCCBEigAwIBAgIRANsn6eS1hYK93tsNS/iNfzcwDQYJKoZIhvcN
# AQELBQAwfTELMAkGA1UEBhMCR0IxGzAZBgNVBAgTEkdyZWF0ZXIgTWFuY2hlc3Rl
# cjEQMA4GA1UEBxMHU2FsZm9yZDEaMBgGA1UEChMRQ09NT0RPIENBIExpbWl0ZWQx
# IzAhBgNVBAMTGkNPTU9ETyBSU0EgQ29kZSBTaWduaW5nIENBMB4XDTE4MDUyMjAw
# MDAwMFoXDTIxMDUyMTIzNTk1OVowgawxCzAJBgNVBAYTAkNIMQ0wCwYDVQQRDAQ4
# NDgzMQswCQYDVQQIDAJaSDESMBAGA1UEBwwJS29sbGJydW5uMRkwFwYDVQQJDBBI
# YWxkZW5zdHJhc3NlIDMxMQ0wCwYDVQQSDAQ4NDgzMRUwEwYDVQQKDAxSb2dlciBa
# YW5kZXIxFTATBgNVBAsMDFphbmRlciBUb29sczEVMBMGA1UEAwwMUm9nZXIgWmFu
# ZGVyMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA1ujnILmAULVtVv3b
# /CDpM6RCdLV9Zjg+CDJFWLBzzjwAcHueV0mv4YgF4WoOhuc3o7GcIvl3P1DqxW97
# ex8cCfFcqdObZszKpP9OyeU5ft4c/rmfPC6PD2sKEWIIvLHAw/RXFS4RFoHngyGo
# 4070NFEMfFdQOSvBwHodsa128FG8hThRn8lXlWJG3327o39kLfawFAaCtfqEBVDd
# k4lYLl2aRpvuobfEATZ016qAHhxkExtuI007gGH58aokxpX+QWJI6T/Bj5eBO4Lt
# IqS6JjJdkRZPNc4Pa98OA+91nxoY5uZdrCrKReDeZ8qNZcyobgqAaCLtBS2esDFN
# 8HMByQIDAQABo4IBqTCCAaUwHwYDVR0jBBgwFoAUKZFg/4pN+uv5pmq4z/nmS71J
# zhIwHQYDVR0OBBYEFE+rkhTxw3ewJzXsZWbrdnRwy7y0MA4GA1UdDwEB/wQEAwIH
# gDAMBgNVHRMBAf8EAjAAMBMGA1UdJQQMMAoGCCsGAQUFBwMDMBEGCWCGSAGG+EIB
# AQQEAwIEEDBGBgNVHSAEPzA9MDsGDCsGAQQBsjEBAgEDAjArMCkGCCsGAQUFBwIB
# Fh1odHRwczovL3NlY3VyZS5jb21vZG8ubmV0L0NQUzBDBgNVHR8EPDA6MDigNqA0
# hjJodHRwOi8vY3JsLmNvbW9kb2NhLmNvbS9DT01PRE9SU0FDb2RlU2lnbmluZ0NB
# LmNybDB0BggrBgEFBQcBAQRoMGYwPgYIKwYBBQUHMAKGMmh0dHA6Ly9jcnQuY29t
# b2RvY2EuY29tL0NPTU9ET1JTQUNvZGVTaWduaW5nQ0EuY3J0MCQGCCsGAQUFBzAB
# hhhodHRwOi8vb2NzcC5jb21vZG9jYS5jb20wGgYDVR0RBBMwEYEPcm9nZXJAemFu
# ZGVyLmNoMA0GCSqGSIb3DQEBCwUAA4IBAQBHs/5P4BiQqAuF83Z4R0fFn7W4lvfE
# 6KJOKpXajK+Fok+I1bDl1pVC9JIqhdMt3tdOFwvSl0/qQ9Sp2cZnMovaxT8Bhc7s
# +PDbzRlklGGRlnVg6i7RHnJ90bRdxPTFUBbEMLy7UAjQ4iPPfRoxaR4rzF3BLaaz
# b7BoGc/oEPIMo/WmXWFngeHAVQ6gVlr2WXrKwHo8UlN0jmgzR7QrD3ZHbhR4yRNq
# M97TgVp8Fdw3o+PnwMRj4RIeFiIr9KGockQWqth+W9CDRlTgnxE8MhKl1PbUGUFM
# DcG3cV+dFTI8P2/sYD+aQHdBr0nDT2RWSgeEchQ1s/isFwOVBrYEqqf7MIIF4DCC
# A8igAwIBAgIQLnyHzA6TSlL+lP0ct800rzANBgkqhkiG9w0BAQwFADCBhTELMAkG
# A1UEBhMCR0IxGzAZBgNVBAgTEkdyZWF0ZXIgTWFuY2hlc3RlcjEQMA4GA1UEBxMH
# U2FsZm9yZDEaMBgGA1UEChMRQ09NT0RPIENBIExpbWl0ZWQxKzApBgNVBAMTIkNP
# TU9ETyBSU0EgQ2VydGlmaWNhdGlvbiBBdXRob3JpdHkwHhcNMTMwNTA5MDAwMDAw
# WhcNMjgwNTA4MjM1OTU5WjB9MQswCQYDVQQGEwJHQjEbMBkGA1UECBMSR3JlYXRl
# ciBNYW5jaGVzdGVyMRAwDgYDVQQHEwdTYWxmb3JkMRowGAYDVQQKExFDT01PRE8g
# Q0EgTGltaXRlZDEjMCEGA1UEAxMaQ09NT0RPIFJTQSBDb2RlIFNpZ25pbmcgQ0Ew
# ggEiMA0GCSqGSIb3DQEBAQUAA4IBDwAwggEKAoIBAQCmmJBjd5E0f4rR3elnMRHr
# zB79MR2zuWJXP5O8W+OfHiQyESdrvFGRp8+eniWzX4GoGA8dHiAwDvthe4YJs+P9
# omidHCydv3Lj5HWg5TUjjsmK7hoMZMfYQqF7tVIDSzqwjiNLS2PgIpQ3e9V5kAoU
# GFEs5v7BEvAcP2FhCoyi3PbDMKrNKBh1SMF5WgjNu4xVjPfUdpA6M0ZQc5hc9IVK
# aw+A3V7Wvf2pL8Al9fl4141fEMJEVTyQPDFGy3CuB6kK46/BAW+QGiPiXzjbxghd
# R7ODQfAuADcUuRKqeZJSzYcPe9hiKaR+ML0btYxytEjy4+gh+V5MYnmLAgaff9UL
# AgMBAAGjggFRMIIBTTAfBgNVHSMEGDAWgBS7r34CPfqm8TyEjq3uOJjs2TIy1DAd
# BgNVHQ4EFgQUKZFg/4pN+uv5pmq4z/nmS71JzhIwDgYDVR0PAQH/BAQDAgGGMBIG
# A1UdEwEB/wQIMAYBAf8CAQAwEwYDVR0lBAwwCgYIKwYBBQUHAwMwEQYDVR0gBAow
# CDAGBgRVHSAAMEwGA1UdHwRFMEMwQaA/oD2GO2h0dHA6Ly9jcmwuY29tb2RvY2Eu
# Y29tL0NPTU9ET1JTQUNlcnRpZmljYXRpb25BdXRob3JpdHkuY3JsMHEGCCsGAQUF
# BwEBBGUwYzA7BggrBgEFBQcwAoYvaHR0cDovL2NydC5jb21vZG9jYS5jb20vQ09N
# T0RPUlNBQWRkVHJ1c3RDQS5jcnQwJAYIKwYBBQUHMAGGGGh0dHA6Ly9vY3NwLmNv
# bW9kb2NhLmNvbTANBgkqhkiG9w0BAQwFAAOCAgEAAj8COcPu+Mo7id4MbU2x8U6S
# T6/COCwEzMVjEasJY6+rotcCP8xvGcM91hoIlP8l2KmIpysQGuCbsQciGlEcOtTh
# 6Qm/5iR0rx57FjFuI+9UUS1SAuJ1CAVM8bdR4VEAxof2bO4QRHZXavHfWGshqknU
# fDdOvf+2dVRAGDZXZxHNTwLk/vPa/HUX2+y392UJI0kfQ1eD6n4gd2HITfK7ZU2o
# 94VFB696aSdlkClAi997OlE5jKgfcHmtbUIgos8MbAOMTM1zB5TnWo46BLqioXwf
# y2M6FafUFRunUkcyqfS/ZEfRqh9TTjIwc8Jvt3iCnVz/RrtrIh2IC/gbqjSm/Iz1
# 3X9ljIwxVzHQNuxHoc/Li6jvHBhYxQZ3ykubUa9MCEp6j+KjUuKOjswm5LLY5TjC
# qO3GgZw1a6lYYUoKl7RLQrZVnb6Z53BtWfhtKgx/GWBfDJqIbDCsUgmQFhv/K53b
# 0CDKieoofjKOGd97SDMe12X4rsn4gxSTdn1k0I7OvjV9/3IxTZ+evR5sL6iPDAZQ
# +4wns3bJ9ObXwzTijIchhmH+v1V04SF3AwpobLvkyanmz1kl63zsRQ55ZmjoIs24
# 75iFTZYRPAmK0H+8KCgT+2rKVI2SXM3CZZgGns5IW9S1N5NGQXwH3c/6Q++6Z2H/
# fUnguzB9XIDj5hY5S6cxggI0MIICMAIBATCBkjB9MQswCQYDVQQGEwJHQjEbMBkG
# A1UECBMSR3JlYXRlciBNYW5jaGVzdGVyMRAwDgYDVQQHEwdTYWxmb3JkMRowGAYD
# VQQKExFDT01PRE8gQ0EgTGltaXRlZDEjMCEGA1UEAxMaQ09NT0RPIFJTQSBDb2Rl
# IFNpZ25pbmcgQ0ECEQDbJ+nktYWCvd7bDUv4jX83MAkGBSsOAwIaBQCgeDAYBgor
# BgEEAYI3AgEMMQowCKACgAChAoAAMBkGCSqGSIb3DQEJAzEMBgorBgEEAYI3AgEE
# MBwGCisGAQQBgjcCAQsxDjAMBgorBgEEAYI3AgEVMCMGCSqGSIb3DQEJBDEWBBRS
# ELhohpGeZ8x06Jw2grvJw3zN7zANBgkqhkiG9w0BAQEFAASCAQAj1TyHdAZhI77Q
# j+tIUIkAShjn6xyClIZB2dgzuc9sOw3wLC9tICBhxHUexPQb9Jua2DXVjggH5LuZ
# YbWZqnM6k03B2Z+/eMKeq+NS9UMlKq5IwNGjUJ2ADfMGF6K4g/gMn8x2sAewR0cp
# xjXAlnpEKtQ+JymRxdGUZSRGko4+78Wa954BqEPZRoj+2+m+2ouWgCZj1p0cN33A
# 57rRVClDO70gaRGI7xGgR4pRZ/cuck3MXNFK7Cwp8iRQL4jnHCg4V5RWxGM3HoZg
# zOJP7KZAPIoHRR6lRkvjvJCNPlTn0gnkP1H9cIMBi0PaGdKH8Lg7he7R0doaQbVl
# l8pMco/+
# SIG # End signature block
