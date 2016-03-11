/*
    Copyright 2016 Zoey (Zoryn)

    Storm is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Storm is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Storm.  If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Storm.ExternalEvent;
using Storm.StardewValley;
using Storm.StardewValley.Event;
using Storm.StardewValley.Wrapper;

namespace MovementSpeedModifier
{
    [Mod]
    public class MovementSpeedModifier : DiskResource
    {
        public Config ModConfig { get; private set; }

        [Subscribe]
        public void InitializeCallback(InitializeEvent @event)
        {
            var configLocation = Path.Combine(ParentPathOnDisk, "Config.json");
            if (!File.Exists(configLocation))
            {
                Console.WriteLine("The config file for MovementSpeedModifier was not found, attempting creation...");
                ModConfig = new Config();
                ModConfig.EnableDiagonalMovementSpeedFix = true;
                ModConfig.PlayerRunningSpeed = 5;
                ModConfig.PlayerWalkingSpeed = 2;
                File.WriteAllBytes(configLocation, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(ModConfig)));
                Console.WriteLine("The config file for MovementSpeedModifier has been loaded.\n\tDiagonalFix: {0}, PlayerWalkingSpeed: {1}, PlayerRunningSpeed: {2}", 
                    ModConfig.EnableDiagonalMovementSpeedFix, ModConfig.PlayerWalkingSpeed, ModConfig.PlayerRunningSpeed);
            }
            else
            {
                ModConfig = JsonConvert.DeserializeObject<Config>(Encoding.UTF8.GetString(File.ReadAllBytes(configLocation)));
                Console.WriteLine("The config file for MovementSpeedModifier has been loaded.\n\tDiagonalFix: {0}, PlayerWalkingSpeed: {1}, PlayerRunningSpeed: {2}", 
                    ModConfig.EnableDiagonalMovementSpeedFix, ModConfig.PlayerWalkingSpeed, ModConfig.PlayerRunningSpeed);
            }

            Console.WriteLine("MovementSpeedModifier Initialization Completed");
        }

        [Subscribe]
        public void UpdateCallback(PreUpdateEvent @event)
        {
            var player = @event.LocalPlayer;
            if (player.Running)
                player.Speed = ModConfig.PlayerRunningSpeed;
            else
                player.Speed = ModConfig.PlayerWalkingSpeed;

            if (ModConfig.EnableDiagonalMovementSpeedFix)
                player.MovementDirections.Clear();
        }
    }

    public class Config
    {
        public bool EnableDiagonalMovementSpeedFix { get; set; }
        public int PlayerWalkingSpeed { get; set; }
        public int PlayerRunningSpeed { get; set; }
    }
}
