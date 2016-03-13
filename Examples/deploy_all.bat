@echo off
pushd %~dp0

set CONFIG=%1

if "%CONFIG%"=="" (
	set /p CONFIG="Deploy which config? (debug/release): "
)

if /I "%CONFIG%" NEQ "debug" (
	if /I "%CONFIG%" NEQ "release" (
		echo Unknown config "%CONFIG%", exiting...
		exit /b
	)
)

set MODS_DIR=%AppData%\StardewValley\Mods
set OUTPUT_DIR=bin\%CONFIG%

rem Copy all the built examples to the Mods directory
xcopy /E /I /Y "Example-Config-Mod\StormTestMod\%OUTPUT_DIR%" "%MODS_DIR%\Example-Config-Mod"
xcopy /E /I /Y "Freeze-Time-Mod\Freeze-Time-Mod\%OUTPUT_DIR%" "%MODS_DIR%\Freeze-Time-Mod"
xcopy /E /I /Y "Movement-Speed-Modifier-Mod\MovementSpeedModifier\%OUTPUT_DIR%" "%MODS_DIR%\Movement-Speed-Modifier-Mod"
xcopy /E /I /Y "ResourceExample\ResourceExample\%OUTPUT_DIR%" "%MODS_DIR%\ResourceExample"
xcopy /E /I /Y "Subclass-Test-Mod\Subclass-Test-Mod\%OUTPUT_DIR%" "%MODS_DIR%\Subclass-Test-Mod"

rem Copy manifest-only examples
xcopy /E /I /Y "ManifestResouce" "%AppData%\StardewValley\Mods\ManifestResouce"

popd
