@echo off
setlocal
echo ----------------------------------------
echo [Ini2Xaml]
echo ----------------------------------------
set "OriginDir=%cd%"
cd /d %~dp0
if exist net8.0 rmdir /q /s net8.0
::if exist net9.0 rmdir /q /s net9.0
set "ProjectPath=..\..\..\Tools\Ini2Xaml\SimpleOverlayTheme.Ini2Xaml.csproj"
echo ** [[96mnet8.0[0m] [94mpublish[0m
dotnet publish "%ProjectPath%" -f net8.0 -c Release
::echo(
::echo ** [[96mnet9.0[0m] [94mpublish[0m
::dotnet publish "%ProjectPath%" -f net9.0 -c Release
cd /d "%OriginDir%"
endlocal