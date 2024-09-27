$name = "wsearch"

#Получить список служб и их состояние: 
Get-Service
#Вывести имя, статус и доступные возможности любой службы:
Get-Service -Name "$name"
#Вывести службы, необходимые для запуска текущей службы: 
Get-Service "$name" | Select-Object -ExpandProperty DependentServices
#Вывести зависимые службы от текущей:
Get-Service "$name" | Select-Object -ExpandProperty ServicesDependedon
#проверить, что в системе имеется указанная служба: 
Get-Service -Name "$name"
#Остановить любую службу, включая зависимые:
Stop-Service -Name "$name" -Force
#Запустить любую службу, включая зависимые: 
Start-Service -Name "$name" 
#Отобразить список всех служб, работа которых может быть приостановлена: 
Get-Service | Where-Object { $_.status -eq 'running'}
#Приостановить любую службу и возобновить ее работу:
Suspend-Service -Name "$name"
Resume-Service -Name "$name"
#изменить тип запуска службы - ручной, автоматический: 
Set-Service -Name "$name" -StartupType Automatic
Set-Service -Name "$name" -StartupType Manual 
#Создать новую службу Testservice в Windows:
New-Service -Name "TestService" -BinaryPathName "C:\sluzba.exe"
#Получить информацию о режиме запуска и описание службы:
Get-WmiObject Win32_Service -Filter "Name='TestService'" | Select-Object StartMode, Description
#получить имя учетной записи, которая используется для запуска службы Testservice: 
Get-WmiObject Win32_Service -Filter "Name='TestService'" | Select-Object StartName 
#изменить имя и пароль учетной записи указанной службы: 
$Svc = Get-WmiObject Win32_service -Filter "Name='TestService'"
$Svc.Change($Null, $Null, $Null, $Null, $Null, $Null, "User", "Password")
#Удалить службу: 
Get-Service -Name "TestService" | Stop-Service -Force
Get-WmiObject Win32_Service -Filter "Name='TestService'" | Invoke-WmiMethod -Name Delete