using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Core.Clients.Implementations;
using WeatherApp.Core.Enums;
using WeatherApp.Core.Models.REST;

namespace WeatherApp.Helpers.REST
{
    public static class WeatherREST
    {
        public static readonly string baseURL = "https://api.openweathermap.org/";

        public static async Task<List<LocationResponse>> GetLocation(string name)
        {
            var response = await RestClient.Instance.Execute<List<LocationResponse>>($"{baseURL}geo/1.0/direct?q={name}&limit={Settings.LocationsLimit}&appid={Settings.AppId}", ContentType.JSON, HttpMethodType.GET);
            if (response == null || response.Count == 0)
            {

                return null;
            }
            return response;

        }

        public static async Task<WeatherResponse> GetWeather(double longitude, double latitude)
        {
            var response = await RestClient.Instance.Execute<WeatherResponse>($"{baseURL}data/2.5/weather?lat={latitude}&lon={longitude}&appid={Settings.AppId}", ContentType.JSON, HttpMethodType.GET);
            if (response == null)
            {

                return null;
            }
            return response;

        }
    }
}
