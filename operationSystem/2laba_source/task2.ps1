Get-Process | Get-Member -MemberType Properties | Select-Object Name | Out-File "C:\Users\5555k\Documents\ДГТУ-MSI\-- 3 курс - 5 семестр\Операционные системы\2laba_source\ProcessesTable.txt"
$total = (Get-Process | Get-Member -MemberType Properties).Count
Write-Host "Количество свойств процессов составляет = $total"