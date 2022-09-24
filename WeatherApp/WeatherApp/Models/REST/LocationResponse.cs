using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace WeatherApp.Core.Models.REST
{
    public class LocationResponse
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("local_names")]
        public LocalNames LocalNames { get; set; }

        [JsonProperty("lat")]
        public double Lat { get; set; }

        [JsonProperty("lon")]
        public double Lon { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }

    public class LocalNames
    {
        [JsonProperty("lt")]
        public string Lt { get; set; }

        [JsonProperty("es")]
        public string Es { get; set; }

        [JsonProperty("pt")]
        public string Pt { get; set; }

        [JsonProperty("uk")]
        public string Uk { get; set; }

        [JsonProperty("he")]
        public string He { get; set; }

        [JsonProperty("la")]
        public string La { get; set; }

        [JsonProperty("en")]
        public string En { get; set; }

        [JsonProperty("ja")]
        public string Ja { get; set; }

        [JsonProperty("sk")]
        public string Sk { get; set; }

        [JsonProperty("sr")]
        public string Sr { get; set; }

        [JsonProperty("pl")]
        public string Pl { get; set; }

        [JsonProperty("be")]
        public string Be { get; set; }

        [JsonProperty("it")]
        public string It { get; set; }

        [JsonProperty("ru")]
        public string Ru { get; set; }

        [JsonProperty("eo")]
        public string Eo { get; set; }

        [JsonProperty("bg")]
        public string Bg { get; set; }

        [JsonProperty("zh")]
        public string Zh { get; set; }

        [JsonProperty("hu")]
        public string Hu { get; set; }

        [JsonProperty("ar")]
        public string Ar { get; set; }

        [JsonProperty("yi")]
        public string Yi { get; set; }

        [JsonProperty("lv")]
        public string Lv { get; set; }

        [JsonProperty("fr")]
        public string Fr { get; set; }

        [JsonProperty("mk")]
        public string Mk { get; set; }

        [JsonProperty("de")]
        public string De { get; set; }

        [JsonProperty("cs")]
        public string Cs { get; set; }
    }

}
