@echo off
REM User Configuration: Repository and File Information
set REPO_OWNER=Natel210
set REPO_NAME=SimpleFileIO
set TAG_NAME=v0.1.92
set ASSET_NAME=Produced.Dll.zip
set OUTPUT_DIR=.

REM Set the GitHub release download URL
set DOWNLOAD_URL=https://github.com/%REPO_OWNER%/%REPO_NAME%/releases/download/%TAG_NAME%/%ASSET_NAME%

REM Download the file
echo Downloading: %DOWNLOAD_URL%
curl -L -o "%ASSET_NAME%" "%DOWNLOAD_URL%"

IF NOT EXIST "%ASSET_NAME%" (
    echo Download failed: %ASSET_NAME%
    exit /b 1
)

REM Extract the ZIP file
echo Extracting: %ASSET_NAME%
powershell -Command "Expand-Archive -Path '%ASSET_NAME%' -DestinationPath '%OUTPUT_DIR%'"

IF ERRORLEVEL 1 (
    echo Extraction failed.
    exit /b 1
)

REM Delete the downloaded ZIP file (optional)
del /f /q "%ASSET_NAME%"

echo Operation complete! Files are located in %OUTPUT_DIR%.
pause
