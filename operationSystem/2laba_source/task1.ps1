Get-ChildItem -Path "C:\Windows" -Filter "*.bmp" |
Where-Object { $_.Length -gt 50000 } |
Select-Object Name, Length, @{Name="Size(MB)";Expression={$_.Length / 1MB}} |
Format-Table -AutoSize |
Out-File -FilePath "C:\Users\5555k\Documents\ДГТУ-MSI\-- 3 курс - 5 семестр\Операционные системы\2laba_source\WindowsBmps.txt"