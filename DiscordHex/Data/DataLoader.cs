﻿using System;
using System.Linq;

namespace DiscordHex.Data
{
    internal class DataLoader
    {    
        private readonly SettingsRepository _settingsRepository;

        public DataLoader()
        {
            _settingsRepository = new SettingsRepository();
        }
        
        internal void LoadData()
        {
            var settings = _settingsRepository.GetSpettings();

#if DEBUG
            Environment.SetEnvironmentVariable("Settings_Token", settings.FirstOrDefault(x => x.Name == "tokenDebug")?.Value);
#endif
#if !DEBUG
            Environment.SetEnvironmentVariable("Settings_Token", settings.FirstOrDefault(x => x.Name == "token")?.Value);
#endif

            Environment.SetEnvironmentVariable("Settings_Prefix", settings.FirstOrDefault(x => x.Name == "prefix")?.Value);
            Environment.SetEnvironmentVariable("Settings_GiphyToken", settings.FirstOrDefault(x => x.Name == "giphyToken")?.Value);
        }
    }
}
