@echo off
setlocal enabledelayedexpansion
set "file=%1"
set /a real_count=0
set /a int_count=0

for /f "tokens=*" %%l in (%file%) do (
    set "line=%%~l"
    set "line=!line: =!"
    if not "!line!"=="" (
        if "!line:~0,1!" geq "0" if "!line:~0,1!" leq "9" (
            if "!line:~1,1!"=="." (
                set /a real_count+=1
            ) else (
                set /a int_count+=1
            )
        )
    )
)

echo Real numbers: !real_count!
echo Integers: !int_count!
