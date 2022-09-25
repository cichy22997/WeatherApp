using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Core.Models.REST;

namespace WeatherApp.Models
{
    public class WeatherModel : BaseModel
    {
        public WeatherModel(WeatherResponse response, string name)
        {
            CityName = name;
            StationName = response.Name;
            Longitude = response.Coord.Lon;
            Latitude = response.Coord.Lat;
            WeatherType = response.Weather[0].Main;
            WeatherTypeDescription = response.Weather[0].Description;
            MainWeatherInfo = response.Main;
        }

        private string cityName = "";
        public string CityName
        {
            get => cityName;
            set => SetProperty(ref cityName, value);
        }

        private string stationName = "";
        public string StationName
        {
            get => stationName;
            set => SetProperty(ref stationName, value);
        }

        private double latitude;
        public double Latitude
        {
            get => latitude;
            set => SetProperty(ref latitude, value);
        }

        private double longitude;
        public double Longitude
        {
            get => longitude;
            set => SetProperty(ref longitude, value);
        }

        private string weatherType;
        public string WeatherType
        {
            get => weatherType;
            set => SetProperty(ref weatherType, value);
        }

        private string weatherTypeDescription;
        public string WeatherTypeDescription
        {
            get => weatherTypeDescription;
            set => SetProperty(ref weatherTypeDescription, value);
        }


        private Main mainWeatherInfo;
        public Main MainWeatherInfo
        {
            get => mainWeatherInfo;
            set => SetProperty(ref mainWeatherInfo, value);
        }

    }
}
