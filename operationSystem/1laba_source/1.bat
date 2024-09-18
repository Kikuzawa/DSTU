@echo off
set "dir=%1"
set "ext=%2"

for /f "tokens=*" %%f in ('dir /b /a-d "%dir%\*.%ext%"') do (
    echo %%~nf
)
