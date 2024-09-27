# Импорт модуля ScheduledTasks
Import-Module ScheduledTasks -ErrorAction SilentlyContinue

# Настройка параметров задания
$taskName = "MyScheduledTask"
$trigger = New-ScheduledTaskTrigger -At 10:00am -Daily
$user = "NT AUTHORITY\SYSTEM"
$action = New-ScheduledTaskAction -Execute "PowerShell.exe" -Argument "-NoProfile -ExecutionPolicy Bypass -File C:\paint.ps1"

# Создание и регистрация задания
$task = New-ScheduledTask -Action $action -Trigger $trigger
Register-ScheduledTask -TaskName $taskName -InputObject $task -Force

Export-ScheduledTask "$taskName" | out-file C:\hello.xml

Write-Host "Задание '$taskName' успешно создано и экспортировано."