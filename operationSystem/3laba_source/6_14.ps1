# Создание самоподписанного сертификата 
$cert = New-SelfSignedCertificate -CertstoreLocation Cert:\LocalMachine\My -DnsName "localhost" -KeyLength 2048 -NotAfter (Get-Date).AddYears(3)

# Экспорт сертификата в файл (для распространения на все пк) certlm.msc
$filePath = "C:\Users\5555k\Documents\ДГТУ-MSI\-- 3 курс - 5 семестр\Операционные системы\3laba_source\test.cer"
$bytes = $cert.Export([Security.Cryptography.X509Certificates.X509ContentType]::Cert)
[System.IO.File]::WriteAllBytes($filePath, $bytes)

# Импорт сертификата в персональное хранилище компьютера
$Certstore = Get-ChildItem -Path Cert:\LocalMachine\My | where-Object {$_.Thumbprint -eq $cert.Thumbprint}
Import-Certificate -CertstoreLocation Cert:\LocalMachine\My -FilePath $CertPath

# Удаление файла сертификата после импорта
Remove-Item $CertPath

# Вывод всеx параметров сертификата по отпечатку (Thumbprint) 
$CertParams = Get-ChildItem -Path Cert:\LocalMachine\My | where-Object {$_.Thumbprint -eq $Cert.Thumbprint }
$CertParams | Format-List

write-Host "Сертификат успешно создан, импортирован и его параметры выведены."
