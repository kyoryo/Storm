using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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

        public virtual Config UpdateConfig(Config baseConfig)
        {
            if (JObject == null)
                return baseConfig;

            string p = baseConfig.ConfigLocation;
            Config uConfig = (Config)Activator.CreateInstance(baseConfig.GetType());
            uConfig = GenerateBaseConfig(uConfig);
            uConfig.ConfigLocation = p;

            foreach (var v in JObject.Properties())
            {
                try
                {
                    uConfig.GetType().GetProperty(v.Name).SetValue(uConfig, v.Value);
                }
                catch
                {
                    //Console.WriteLine("Failed to assign property [{0}] from json to property [{0}] in Config", v.Name);
                    //No output?
                }
            }

            WriteConfig(uConfig);

            return uConfig;
        }

        public virtual Config LoadConfig(Config baseConfig)
        {
            if (!File.Exists(baseConfig.ConfigLocation))
            {
                var v = (Config)baseConfig.GetType().GetMethod("GenerateBaseConfig", BindingFlags.Public | BindingFlags.Instance).Invoke(baseConfig, new object[] { baseConfig });
                WriteConfig(v);
            }
            else
            {
                string p = baseConfig.ConfigLocation;
                JObject j = new JObject();

                try
                {
                    j = JObject.Parse(Encoding.UTF8.GetString(File.ReadAllBytes(baseConfig.ConfigLocation)));
                    baseConfig = (Config) j.ToObject(baseConfig.GetType());
                }
                catch
                {
                    Console.WriteLine("Invalid JSON Moved: " + p);
                    File.Move(p, Path.Combine(Path.GetDirectoryName(p), Path.GetFileNameWithoutExtension(p) + "." + Guid.NewGuid() + ".json")); //Get it out of the way for a new one
                    var v = (Config)baseConfig.GetType().GetMethod("GenerateBaseConfig", BindingFlags.Public | BindingFlags.Instance).Invoke(baseConfig, new object[] { baseConfig });
                    WriteConfig(v);
                }

                baseConfig.ConfigLocation = p;
                baseConfig.JObject = j;

                baseConfig = UpdateConfig(baseConfig);
            }

            return baseConfig;
        }

        public virtual void WriteConfig(Config baseConfig)
        {
            File.WriteAllBytes(baseConfig.ConfigLocation, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(baseConfig, baseConfig.GetType(), Formatting.Indented, new JsonSerializerSettings())));
        }

        public static string GetBasePath(DiskResource theMod)
        {
            return theMod.PathOnDisk + "\\Config.json";
        }

        public static Config Instance { get { return new Config(); } }
    }
}
