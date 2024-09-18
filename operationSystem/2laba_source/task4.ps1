# Получение списка всех процессов
$allProcesses = Get-Process

# Фильтрация и сортировка процессов
$filteredProcesses = $allProcesses | Where-Object {$_.CPU -gt 5} | Sort-Object -Property Id

# Создание HTML-файла
$filteredProcesses | Select-Object Id, Name, WorkingSet, CPU | ConvertTo-Html -Head "<style>table {border-collapse: collapse; width: 100%;} th, td {border: 1px solid black; padding: 8px; text-align: left;} tr:nth-child(even){background-color: #f2f2f2;}</style>" -Title "List of Processes" | Out-File -FilePath "C:\Users\5555k\Documents\ДГТУ-MSI\-- 3 курс - 5 семестр\Операционные системы\2laba_source\processes.html"

Write-Host "HTML-файл 'C:\Users\5555k\Documents\ДГТУ-MSI\-- 3 курс - 5 семестр\Операционные системы\2laba_source\processes.html' успешно создан"
