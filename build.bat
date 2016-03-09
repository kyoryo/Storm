@echo off

rem path to msbuild.exe
path=%path%;C:\Users\Matt\AppData\Local\Atlassian\SourceTree\git_local\bin

rem go to current folder
cd %~dp0

git pull

call "C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\Tools\VsMSBuildCmd.bat"

msbuild build.proj