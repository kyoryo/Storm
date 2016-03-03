<h1>*** STORM **</h1>
Storm is a modding API for the game Stardew Valley. Storm works by dynamically modifying the game's executable at runtime, to expose data, provide callbacks,
and provide abstraction for a stable, maintainable modding environment. <br><br>
We use Mono.Cecil for our MSIL injection, DynamicProxy for creating instances of any 
games classes, and Json.NET for serialization.

<h1>*** INSTALLATION/USAGE **</h1>
Launcher: Compile Storm, and place it in the same directory as the game. Launching Storm will cause the Game to be launched.<br>
Mods: Mods each have their own individual folder, and go in AppData/storm-mods/mod-name/<br><br>

<h1>*** CONTRIBUTORS ***</h1>
Please stay consistent with the overall style that has been used throughout the project.<br>
Any changes breaking this rule will be denied.