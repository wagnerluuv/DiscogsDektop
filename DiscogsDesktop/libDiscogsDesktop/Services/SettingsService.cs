using System;
using JetBrains.Annotations;
using libDiscogsDesktop.Models;
using Newtonsoft.Json;

namespace libDiscogsDesktop.Services
{
    public static class SettingsService
    {
        public static DiscogsDesktopSettings Settings { get; private set; }

        public static void LoadSettings(string serializedSettings)
        {
            Settings = JsonConvert.DeserializeObject<DiscogsDesktopSettings>(serializedSettings);
        }

        public static string GetSerializedSettings()
        {
            return JsonConvert.SerializeObject(Settings);
        }
    }
}