﻿using System.Collections.Concurrent;
using Newtonsoft.Json;
using System.IO;

namespace DiscordHex.Core
{
    public static class BotConfig
    {
        private static ConcurrentDictionary<string, string> _configuration = new ConcurrentDictionary<string, string>();
        private static readonly JsonSerializer JsonSerializer = new JsonSerializer();
#if DEBUG
        private const string ConfigFile = @"c:\RainBot\Config.cfg";
#endif
#if !DEBUG
        private const string ConfigFile = @"/etc/RainBot/config.cfg";
#endif

        public static bool IsDragonMom(ulong id)
        {
            return id == 462658205009575946;
        }

        public static string GetValue(string value)
        {
            if (_configuration.IsEmpty) LoadConfig();

            _configuration.TryGetValue(value, out var res);
            return res;
        }

        private static void LoadConfig()
        {
            if (!File.Exists(ConfigFile))
            {
                Log.Fatal($"Can't find config file: '{ConfigFile}'");
                throw new IOException($"Can't find config file: '{ConfigFile}'");
            }

            using (var sr = File.OpenText(ConfigFile))
            {
                using (var reader = new JsonTextReader(sr))
                {
                    _configuration = JsonSerializer.Deserialize<ConcurrentDictionary<string, string>>(reader);
                }
            }
        }
    }
}
