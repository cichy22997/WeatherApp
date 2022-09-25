using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Models;

namespace WeatherApp.ViewModels
{
    public class DetailsViewModel: BaseViewModel
    {
        #region Properties
        private WeatherModel weatherModel;
        public WeatherModel WeatherModel
        {
            get => weatherModel;
            set => SetProperty(ref weatherModel, value);
        }
        #endregion
        public DetailsViewModel(WeatherModel model)
        {
            WeatherModel = model;
        }
    }
}
