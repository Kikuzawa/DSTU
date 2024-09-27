# Запуск Paint
Start-Process mspaint.exe

# Бесконечная блокировка скрипта
while ($true) {
    # Ждем ввода Enter
    $null = $Host.UI.RawUI.ReadKey('NoEcho,IncludeKeyDown')
}
