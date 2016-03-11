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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Storm.ExternalEvent;

namespace Storm
{
    public class Config
    {
        [JsonIgnore]
        public virtual JObject JObject { get; protected set; }

        [JsonIgnore]
        public virtual string ConfigLocation { get; protected set; }

        public static Config Instance
        {
            get { return new Config(); }
        }

        public static Config InitializeConfig(string configLocation, Config baseConfig)
        {
            if (baseConfig == null)
            {
                Console.WriteLine("A config must be instantiated before being passed to Initialize.\n\t" + configLocation);
                return null;
            }

            baseConfig.ConfigLocation = configLocation;
            return baseConfig.LoadConfig(baseConfig);
        }

        public virtual Config GenerateBaseConfig(Config baseConfig)
        {
            //Must be implemented in sub-class
            return null;
        }

        public virtual Config LoadConfig(Config baseConfig)
        {
            if (!File.Exists(baseConfig.ConfigLocation))
            {
                var v = (Config)baseConfig.GetType().GetMethod("GenerateBaseConfig", BindingFlags.Public | BindingFlags.Instance).Invoke(baseConfig, new object[] { baseConfig });
                v.WriteConfig();
            }
            else
            {
                var p = baseConfig.ConfigLocation;

                try
                {
                    var j = JObject.Parse(Encoding.UTF8.GetString(File.ReadAllBytes(baseConfig.ConfigLocation)));
                    baseConfig = (Config)j.ToObject(baseConfig.GetType());
                    baseConfig.ConfigLocation = p;
                    baseConfig.JObject = j;

                    baseConfig = UpdateConfig(baseConfig);
                    baseConfig.ConfigLocation = p;
                    baseConfig.JObject = j;

                    baseConfig.WriteConfig();
                }
                catch
                {
                    Console.WriteLine("Invalid JSON Renamed: " + p);
                    if (File.Exists(p))
                        File.Move(p, Path.Combine(Path.GetDirectoryName(p), Path.GetFileNameWithoutExtension(p) + "." + Guid.NewGuid() + ".json")); //Get it out of the way for a new one
                    var v = (Config)baseConfig.GetType().GetMethod("GenerateBaseConfig", BindingFlags.Public | BindingFlags.Instance).Invoke(baseConfig, new object[] { baseConfig });
                    v.WriteConfig();
                }
            }

            return baseConfig;
        }

        public virtual Config UpdateConfig(Config baseConfig)
        {
            try
            {
                //default config with all standard values
                var b = JObject.FromObject(baseConfig.GetType().GetMethod("GenerateBaseConfig", BindingFlags.Public | BindingFlags.Instance).Invoke(baseConfig, new object[] { baseConfig }));
                //user config with their values
                var u = baseConfig.JObject;

                b.Merge(u);

                return (Config)b.ToObject(baseConfig.GetType());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return baseConfig;
        }

        public static string GetBasePath(DiskResource theMod)
        {
            return theMod.PathOnDisk + "\\config.json";
        }
    }

    public static class ConfigExtensions
    {
        public static void WriteConfig(this Config baseConfig)
        {
            var toWrite = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(baseConfig, baseConfig.GetType(), Formatting.Indented, new JsonSerializerSettings()));
            if (!File.Exists(baseConfig.ConfigLocation) || !File.ReadAllBytes(baseConfig.ConfigLocation).SequenceEqual(toWrite))
                File.WriteAllBytes(baseConfig.ConfigLocation, toWrite);
            toWrite = null;
        }

        public static Config ReloadConfig(this Config baseConfig)
        {
            return baseConfig.UpdateConfig(baseConfig);
        }
    }
}