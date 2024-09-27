
$From = "kikuzawa-cyber@yandex.ru"
$To = "kotelevets-k-0905@yandex.ru"
$Subject = "Test message subject from $($env:computername)"
$Body = "Hello, I am kikuzawa, student VKB31"
$Password = "nzwdyydytustqjaw" | ConvertTo-SecureString -AsPlainText -Force
$Credential = New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $From, $Password
Send-MailMessage -From $From -To $To -Subject $Subject -Body $Body -SmtpServer "smtp.yandex.ru" -port 587 -UseSsl -Credential $Credential

