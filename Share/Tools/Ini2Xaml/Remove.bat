@echo off
setlocal
echo ----------------------------------------
echo [Ini2Xaml]
echo ----------------------------------------
set "OriginDir=%cd%"
cd /d %~dp0
if exist net8.0 (
    echo ** Deleate net8.0
    rmdir /q /s net8.0
) else (
    echo ** Skip net8.0
)
::if exist net9.0 (
::    echo ** Deleate net9.0
::    rmdir /q /s net9.0
::) else (
::    echo ** Skip net9.0
::)
cd /d "%OriginDir%"
endlocal