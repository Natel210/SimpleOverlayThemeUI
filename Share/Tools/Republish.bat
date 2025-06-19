@echo off

echo ALL Republishing

call Ini2Xaml\Republish.bat
echo(
call LocalizationDocument\Republish.bat
pause