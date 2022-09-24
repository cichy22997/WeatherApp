using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Core.Enums;

namespace WeatherApp.Core.Clients.Interfaces
{
    public interface IRestClient
    {
        Task<HttpResponseMessage> Execute(string endPoint, ContentType contentType, HttpMethodType method, string json = "", TimeSpan? timeout = null, Dictionary<string, string> headers = null);
        Task<T> Execute<T>(string endPoint, ContentType contentType, HttpMethodType method, string json = "", JsonSerializerSettings jsonSettings = null, TimeSpan? timeout = null, Dictionary<string, string> headers = null);
    }
}