Import-Module NTFSSecurity

$path = "c:\drivers"
$user = "MSI\5555k"
$Rights = "Read, ReadAndExecute, ListDirectory"

$InheritSettings = "Containerinherit, ObjectInherit"
$PropogationSettings = "None"
$RuleType = "Allow"
$acl = Get-Acl $path
$perm = $user, $Rights, $InheritSettings, $PropogationSettings, $RuleType
$rule = New-Object -TypeName System.Security.AccessControl.FileSystemAccessRule -ArgumentList $perm
$acl.SetAccessRule($rule)
$acl | Set-Acl -Path $path

###

$path = "c:\drivers"
$acl = Get-Acl $path
$rules = $acl.Access | where IsInherited -eq $false
$targetrule = $rules | where IdentityReference -eq "MSI\5555k"
$acl.RemoveAccessRule($targetrule)
$acl | Set-Acl -Path $path

###

Add-NTFSAccess -Path C:\drivers -Account 'Гость' -AccessRights 'ExecuteFile' -PassThru

Add-NTFSAccess c:\drivers -Account 'Гость' -AccessRights Modify -AppliesTo ThisFolderOnly

Remove-NTFSAccess -Path C:\drivers -Account 'Гость' -AccessRights FullControl -PassThru

Get-ChildItem -Path C:\drivers -Recurse | Get-NTFSAccess -Account 'Гость' -ExcludeInherited |Remove-NTFSAccess -PassThru

Get-ChildItem -Path C:\drivers -Recurse -Force | Set-NTFSOwner -Account 'Администратор'

Get-ChildItem -Path c:\drivers -Recurse -Directory | Get-NTFSEffectiveAccess | select Account, AccessControlType, AccessRights, FullName