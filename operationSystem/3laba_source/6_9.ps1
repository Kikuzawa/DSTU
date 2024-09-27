Add-Type -AssemblyName System.Windows.Forms
$global:balmsg = New-Object System.Windows.Forms.NotifyIcon
$path = (Get-Process -id $pid).Path
$balmsg.Icon = [System.Drawing.Icon]::ExtractAssociatedIcon($path)
$balmsg.BalloonTipIcon = [System.Windows.Forms.ToolTipIcon]::Warning
$balmsg.BalloonTipText = 'Это текст всплывающего сообщения для пользователя Windows 11. Hello!'
$balmsg.BalloonTipTitle = "Внимание Кирилл!"
$balmsg.Visible = $true
$balmsg.ShowBalloonTip(10000)