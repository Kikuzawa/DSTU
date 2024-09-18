@echo off
setlocal EnableExtensions EnableDelayedExpansion
set base=10000
set baseLog=4
set res.high=0
set res[0]=1

if "%1"=="" (
    echo Пожалуйста, введите число.
    exit /b
)
set /a input=%1

if %input% LSS 0 (
    echo Ошибка: Введено отрицательное число.
    exit /b
) else if %input% GTR 50 (
    echo Ошибка: Введено число больше 50.
    exit /b
)
for /l %%n in (1, 1, %1) do (
  set c=0
  for /l %%i in (0, 1, !res.high!) do (
    set /a c += res[%%i] * %%n
    set /a res[%%i] = c %% %base%
    set /a c /= %base%
  )
  if not !c! == 0 (
    set /a res.high += 1
    set /a res[!res.high!] = c
  )
)
set resStr=!res[%res.high%]!
set /a iBeforeLast = res.high - 1
for /l %%i in (%iBeforeLast%, -1, 0) do (
  set d=%base%!res[%%i]!
  set resStr=!resStr!!d:~-%baseLog%!
)
echo %resStr%