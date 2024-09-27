Get-CimInstance win32_logicaldisk |
Select-Object -Property DeviceID, VolumeName, @{Label='FreeSpace (Gb)'; expression={($_.FreeSpace/1GB).ToString('F2')}},
@{Label='Total (Gb)'; expression={($_.Size/1GB).ToString('F2')}},
@{label='FreePercent'; expression={[Math]::Round(($_.freespace / $_.size) * 100, 2)}}|ft

$percentWarning = 25
$percentCritcal = 22
$ListDisk = Get-WmiObject -Class Win32_LogicalDisk
Foreach($Disk in $ListDisk){
if ($Disk.size -ne $NULL)
{
$DiskFreeSpace = ($Disk.freespace/1GB).ToString('F2')
$DiskFreeSpacePercent = [Math]::Round(($Disk.freespace/$Disk.size) * 100, 2)
if($DiskFreeSpacePercent -lt $percentWarning)
{
$Message= "Warning!"
if($DiskFreeSpacePercent -lt $percentCritcal)
{
$Message= "Alert!"
}

# блок вывода уведомления
$wshell = New-Object -ComObject Wscript.Shell
$Output = $wshell.Popup("На диске $($Disk.DeviceID) осталось свободно всего $DiskFreeSpace ГБ",0,$Message,48)
}
}
}