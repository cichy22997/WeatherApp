using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace WeatherApp.Helpers
{
    public static class Settings
    {

        const string defaultAppId = "5644d38f623183d217506ff92a82cafe";
        public static string AppId
        {
            get => Preferences.Get(nameof(AppId), defaultAppId);
            set => Preferences.Set(nameof(AppId), value);
        }

        public static int LocationsLimit
        {
            get => Preferences.Get(nameof(LocationsLimit), 1);
            set => Preferences.Set(nameof(LocationsLimit), value);
        }

        public static string DefaultCity
        {
            get => Preferences.Get(nameof(DefaultCity), "");
            set => Preferences.Set(nameof(DefaultCity), value);
        }
    }
}
