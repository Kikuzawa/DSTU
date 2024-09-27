Write-Host "Проверка наличия прав администратора..."
$currentUser = New-Object Security.Principal.WindowsPrincipal([Security.Principal.WindowsIdentity]::GetCurrent())
$isAdministrator = $currentUser.IsInRole([Security.Principal.WindowsBuiltInRole] "Administrator")

if (-not $isAdministrator) {
   Write-Host "Скрипт не запущен с правами администратора." -ForegroundColor Yellow
    
    # Запрашиваем повышение привилегий
    $confirmation = Read-Host "Хотите запустить этот скрипт от имени администратора? (Y/N)"
    
    if ($confirmation -eq 'Y' -or $confirmation -eq 'y') {
        Write-Host "Запуск скрипта от имени администратора..." -ForegroundColor Cyan
        
        # Создаем новый процесс PowerShell с правами администратора
        $newProcess = New-Object System.Diagnostics.ProcessStartInfo("PowerShell")
        $newProcess.UseShellExecute = $true
        $newProcess.Verb = "runas"
        $newProcess.Arguments = "& { Start-Process -FilePath `"$($MyInvocation.MyCommand.Definition)`" }"
        
        # Запускаем новый процесс с правами администратора
        [System.Diagnostics.Process]::Start($newProcess)
        }
} else {
    Write-Host "Права администратора есть – продолжение скрипта..." -ForegroundColor Green

}

$confirmation = Read-Host "Нажмите Enter, чтобы закончить: "
