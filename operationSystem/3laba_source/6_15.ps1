# Создание самоподписанного сертификата для кода 
New-SelfSignedCertificate -Type CodesigningCert -CertstoreLocation Cert:\Currentuser\My -Subject "CodesigningCert" -NotAfter (Get-Date).AddYears(3)

# Указываем путь к скрипту, который нужно подписать 
$ScriptPath = "C:\Users\5555k\Documents\ДГТУ-MSI\-- 3 курс - 5 семестр\Операционные системы\3laba_source\paint.ps1"

# Получаем самоподписанный сертификат для кода
$Cert = Get-ChildItem -Path Cert:\Currentuser\My | Where-Object { $_.Subject -match "CodeSigningCert"} | Select-Object -First 1

# Подписание скрипта с использованием сертификата 
Set-AuthenticodeSignature -Certificate $Cert -FilePath $ScriptPath
