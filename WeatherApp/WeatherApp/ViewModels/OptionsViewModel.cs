using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WeatherApp.Core;
using WeatherApp.Enums;
using WeatherApp.Helpers;

namespace WeatherApp.ViewModels
{
    public class OptionsViewModel : BaseViewModel
    {
        #region Commands

        private ICommand acceptLimitCommand;
        public ICommand AcceptLimitCommand => acceptLimitCommand ?? (acceptLimitCommand = new CommandHandler(async () =>
        {
            LocationsLimit = ValidateNumber(LocationsLimit);
            Settings.LocationsLimit = Convert.ToInt32(LocationsLimit);

        }, true));


        #endregion

        #region Properties


        private bool isSystemRadioChecked;
        public bool IsSystemRadioChecked
        {
            get => isSystemRadioChecked;
            set
            {
                SetProperty(ref isSystemRadioChecked, value);
                if (value)
                    ChangeTheme(ThemeType.System);
            }
        }

        private bool isLightRadioChecked;
        public bool IsLightRadioChecked
        {
            get => isLightRadioChecked;
            set
            {
                SetProperty(ref isLightRadioChecked, value);
                if (value)
                    ChangeTheme(ThemeType.Light);
            }
        }

        private bool isDarkRadioChecked;
        public bool IsDarkRadioChecked
        {
            get => isDarkRadioChecked;
            set
            {
                SetProperty(ref isDarkRadioChecked, value);
                if (value)
                    ChangeTheme(ThemeType.Dark);
            }
        }


        private int locationsLimit = Settings.LocationsLimit;
        public double LocationsLimit
        {
            get => locationsLimit;
            set => SetProperty(ref locationsLimit, Convert.ToInt32(ValidateNumber(value)));
        }

        private string appId = Settings.AppId;
        public string AppId
        {
            get => appId;
            set
            {
                SetProperty(ref appId, value);
                Settings.AppId = value;
            }
        }


        #endregion

        public OptionsViewModel()
        {

        }

        public void SetThemeCheckbox()
        {
            switch (ThemeHelper.CurrentTheme)
            {
                case 0:
                    IsSystemRadioChecked = true;
                    break;
                case 1:
                    IsLightRadioChecked = true;
                    break;
                case 2:
                    IsDarkRadioChecked = true;
                    break;
            }
        }


        #region Methods
        public void ChangeTheme(ThemeType type)
        {

            ThemeHelper.CurrentTheme = Convert.ToInt32(type);
            ThemeHelper.SetTheme();
        }

        private int ValidateNumber(double numb)
        {
            numb = Math.Round(numb);
            if (numb <= 0)
            {
                numb = Math.Abs(numb);
            }
            return Convert.ToInt32(numb);
        }

        #endregion
    }
}
