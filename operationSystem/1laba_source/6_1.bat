@echo off
set "file1=%1"
set "file2=%2"
set "file3=%3"
set "output=%4"

if not exist "%file1%" (
    echo Error: File 1 not found
    exit /b 1
)
if not exist "%file2%" (
    echo Error: File 2 not found
    exit /b 1
)
if not exist "%file3%" (
    echo Error: File 3 not found
    exit /b 1
)

copy /b "%file1%" + "%file2%" + "%file3%" "%output%"
