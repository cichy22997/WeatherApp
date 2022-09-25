using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Enums;
using WeatherApp.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace WeatherApp.Helpers
{
    public static class ThemeHelper
    {

        const int _Theme = 0;

        //0 - Default System Theme
        //1 - Light Theme
        //2 - Dark Theme
        public static int CurrentTheme
        {
            get => Preferences.Get(nameof(CurrentTheme), _Theme);
            set => Preferences.Set(nameof(CurrentTheme), value);
        }

        public static void SetTheme()
        {
            switch (CurrentTheme)
            {
                case 0:
                    App.Current.UserAppTheme = Xamarin.Forms.OSAppTheme.Unspecified;
                    break;
                case 1:
                    App.Current.UserAppTheme = Xamarin.Forms.OSAppTheme.Light;
                    break;
                case 2:
                    App.Current.UserAppTheme = Xamarin.Forms.OSAppTheme.Dark;
                    break;
            }
            var nav = App.Current.MainPage as Xamarin.Forms.NavigationPage;
            var enviroment = DependencyService.Get<IEnviroment>();
            if (App.Current.RequestedTheme == OSAppTheme.Dark)
            {
                enviroment?.SetStatusBarColor(((Color)Application.Current.Resources["clr-statusbar-dark"]), false);
                if (nav != null)
                {
                    nav.BarBackgroundColor = ((Color)Application.Current.Resources["clr-statusbar-dark"]);
                    nav.BarTextColor = ((Color)Application.Current.Resources["clr-text-bright"]);
                }
            }
            else
            {
                enviroment?.SetStatusBarColor(((Color)Application.Current.Resources["clr-statusbar"]), true);
                if (nav != null)
                {
                    nav.BarBackgroundColor = ((Color)Application.Current.Resources["clr-statusbar"]);
                    nav.BarTextColor = ((Color)Application.Current.Resources["clr-text-bright"]);
                }
            }
        }

    }
}
