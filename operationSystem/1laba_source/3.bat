@echo off
set /A count=0
for /R %1 %%f IN (.) DO SET /A count = count + 1
ECHO Count of SubDirectories: %count%
pause>nul