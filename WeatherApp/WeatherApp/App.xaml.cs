using System;
using WeatherApp.Helpers;
using WeatherApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            ThemeHelper.SetTheme();

            MainPage = new NavigationPage(new MainView());
        }


        protected override void OnStart()
        {
            ThemeHelper.SetTheme();
            RequestedThemeChanged += App_RequestedThemeChanged;
        }


        protected override void OnSleep()
        {
            ThemeHelper.SetTheme();
            RequestedThemeChanged -= App_RequestedThemeChanged;
        }


        protected override void OnResume()
        {
            ThemeHelper.SetTheme();
            RequestedThemeChanged += App_RequestedThemeChanged;
        }


        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs args)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                ThemeHelper.SetTheme();
            });
        }
    }
}
