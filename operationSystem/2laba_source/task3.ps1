$allProcesses = Get-Process

# Фильтрация и сортировка процессов
$filteredProcesses = $allProcesses | Where-Object {$_.CPU -gt 5} | Sort-Object -Property Id

# Создание текстового файла
$filteredProcesses | Select-Object Id, Name, WorkingSet, CPU | Format-Table -AutoSize | Out-File -FilePath "C:\Users\5555k\Documents\ДГТУ-MSI\-- 3 курс - 5 семестр\Операционные системы\2laba_source\NowProcesses.txt"

Write-Host "Данные о процессах сохранены в файл 'C:\Users\5555k\Documents\ДГТУ-MSI\-- 3 курс - 5 семестр\Операционные системы\2laba_source\NowProcesses.txt'"