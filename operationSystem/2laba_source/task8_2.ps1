ls "C:\Windows\system32" -Filter *.dll|sort -Property CreationTime -Descending|select -last 3 | select name
