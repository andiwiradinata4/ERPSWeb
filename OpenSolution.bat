@echo off
cd /d "C:\Project\Web\ERPSWeb"
git pull origin
set /p userInput=Open Project Solution? [y/n]:
if "%userInput%" EQU "y" (
start "" "C:\Project\Web\ERPSWeb\ERPS.Web\ERPS.Web.sln"
pause
)