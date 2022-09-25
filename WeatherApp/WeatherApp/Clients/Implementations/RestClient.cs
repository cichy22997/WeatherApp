using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherApp.Core.Clients.Interfaces;
using WeatherApp.Core.Enums;
using WeatherApp.Extentions;

namespace WeatherApp.Core.Clients.Implementations
{
    public class RestClient : IRestClient
    {
        private TimeSpan defaultTimeout = TimeSpan.FromSeconds(30);

        private static readonly RestClient instance = new RestClient();

        static RestClient()
        {
        }

        private RestClient()
        {
        }

        public static RestClient Instance
        {
            get
            {
                return instance;
            }
        }

        public async Task<T> Execute<T>(string endPoint, ContentType contentType, HttpMethodType method, string json = "", JsonSerializerSettings jsonSettings = null, TimeSpan? timeout = null, Dictionary<string, string> headers = null)
        {
            T result = default(T);
            var response = await Execute(endPoint, contentType, method, json, timeout, headers);

            var content = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<T>(content, jsonSettings);
            return result;
        }


        public async Task<HttpResponseMessage> Execute(string endPoint, ContentType contentType, HttpMethodType method, string json = "", TimeSpan? timeout = null, Dictionary<string, string> headers = null)
        {
            var task = Task.Run(() => ExecuteRequest(endPoint, contentType, method, json, timeout, headers));

            if (task.Wait(timeout.HasValue ? timeout.Value : defaultTimeout))
                return task.Result;
            else
                throw new Exception($"Timed out. EndPoint: {endPoint}");
        }

        private async Task<HttpResponseMessage> ExecuteRequest(string endPoint, ContentType contentType, HttpMethodType method, string json = "", TimeSpan? timeout = null, Dictionary<string, string> headers = null)
        {
            string result = "";
            HttpResponseMessage response = null;

            using (var client = new HttpClient())
            {
                client.Timeout = timeout.HasValue ? timeout.Value : defaultTimeout;

                if (headers != null)
                    AddHeaders(client, headers);

                var body = method == HttpMethodType.GET || method == HttpMethodType.DELETE
                    ? null
                    : new StringContent($"{json}", Encoding.UTF8, contentType.GetContent());

                try
                {
                    response = null;

                    switch (method)
                    {
                        case HttpMethodType.GET:
                            response = await client.GetAsync(endPoint);
                            break;

                        case HttpMethodType.POST:
                            response = await client.PostAsync(endPoint, body);
                            break;

                        case HttpMethodType.PUT:
                            response = await client.PutAsync(endPoint, body);
                            break;

                        case HttpMethodType.DELETE:
                            response = await client.DeleteAsync(endPoint);
                            break;

                        case HttpMethodType.PATCH:
                        case HttpMethodType.HEAD:
                        case HttpMethodType.OPTIONS:
                            var request = new HttpRequestMessage(new HttpMethod(method.ToString()), endPoint)
                            { Content = body };
                            response = await client.SendAsync(request);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message, ex.InnerException);
                }
            }

            return response;
        }
        private void AddHeaders(HttpClient client, Dictionary<string, string> headers)
        {
            foreach (var header in headers)
                client.DefaultRequestHeaders.Add(header.Key, header.Value);
        }
    }
}
