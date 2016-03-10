<h1>*** STORM ***</h1>
Storm is a modding API for the game Stardew Valley. Storm works by dynamically modifying the game's executable at runtime, to expose data, provide callbacks,
and provide abstraction for a stable, maintainable modding environment.    
We use Mono.Cecil for our MSIL injection, DynamicProxy for creating instances of any 
games classes, and Json.NET for serialization.

<h1>*** INSTALLATION/USAGE ***</h1>
Launcher: Compile Storm, and place it in the same directory as the game. Launching Storm will cause the Game to be launched.  
Mods: Mods each have their own individual folder, and go in AppData/StardewValley/Mods/mod-name/ 

<h1>*** COMPILING ***</h1>
<h3>Pre-requisites</h3>
The following are pre-requisites to being able to download and build the Storm API

* Visual Studio Community Edition 2015
* XNA must be installed (probably already is if you're running Stardew Valley)
* Install Git for Windows from https://git-scm.com/download/win

<h3>Downloading the Project</h3>
* Open a Command Prompt (WIN+R, `cmd` then Enter)
* Navigate to a folder where you'd like the files to be downloaded (such as c:\devel\ for example)
* Run the following command: `git clone https://gitlab.com/Demmonic/Storm.git`

<h3>Opening and building the project</h3>
(Note: ./ refers to the root of the project where it was downloaded!)

* Open ./Storm/Storm.sln in VS 2015
* You *should* be able to build it directly by going to the **Build** menu, then **Build Solution**

<h3>Copying the appropriate files</h3>

There are different copies to be made: 

* `./Dependencies/injectors/interface_injectors.json` and `./Dependencies/injectors/secondary/` should be copied to `%APPDATA%/StardewValley/Storm/`
* All files from `./Storm/Storm/bin/Debug/` should be copied to the StardewValley.exe installation folder.

<h3>Other notes</h3>

* Mod DLLS should be under %APPDATA%/StardewValley/Mods/yourmodname/
* Run `StormLoader.exe` from the game install path to launch with mods.

<h1>*** CONTRIBUTORS ***</h1>
Please stay consistent with the overall style that has been used throughout the project.  
Any changes breaking this rule will be denied.

<h3>*** LICENSING ***</h3>
Any newly contributed files must be prefixed with the GNU GPL license notification. Failing to do so will result in your changes being <i>denied</i>.  
Along with
that, please put your name with the copyright notice at the top of the file when adding/editing files.

<h3>*** EVENT CONTRIBUTION ***</h3>
Please also add your name into the event spreadsheet when implementing Events, otherwise your merge and push requests will be denied.  
Event spreadsheet: https://docs.google.com/spreadsheets/d/1vvHVA3tb1SL6X6GbJY7FayuiuX24VMLBgLS3-KGMfGQ/edit#gid=0