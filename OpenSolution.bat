@echo off
cd /d "D:\My Project\Website\ERPS"
git pull origin
set /p userInput=Open Project Solution? [y/n]:
if "%userInput%" EQU "y" (
start "" "D:\My Project\Website\ERPS\ERPS.Web\ERPS.Web.sln"
pause
)