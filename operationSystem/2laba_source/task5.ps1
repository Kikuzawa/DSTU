# Получаем список всех графических файлов (.jpg и .bmp) в каталоге Windows и его подкаталогах
$files = Get-ChildItem -Path "C:\Windows" -Recurse -File -Include *.jpg, *.bmp

# Суммируем объем всех файлов
$totalSize = $files | Measure-Object -Property Length -Sum

# Выводим результаты
Write-Host "Общий объем всех графических файлов (.jpg и .bmp) в каталоге Windows и его подкаталогах:"
Write-Host "В байтах: $($totalSize.Sum)"
$totalSizeMB = [math]::Round($totalSize.Sum / 1MB, 2)
Write-Host "В мб: $totalSizeMB"

# Дополнительная информация
Write-Host "`nДополнительно:"
Write-Host "Количество файлов: $($files.Count)"

