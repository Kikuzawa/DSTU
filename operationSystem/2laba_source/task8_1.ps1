# Самые наибольшие
ls "C:\Windows\system32" -Filter *.dll|sort -Property Length -Descending|select -First 3 | select name, length


# Самые наименьшие
ls "C:\Windows\system32" -Filter *.dll|sort -Property Length -Descending|select -last 3 | select name, length