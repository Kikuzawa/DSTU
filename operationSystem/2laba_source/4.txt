@ECHO OFF

FOR %%i IN (%1\*.*) DO (IF EXIST %2\%%~NXi ECHO %%~NXi)

pause>nul