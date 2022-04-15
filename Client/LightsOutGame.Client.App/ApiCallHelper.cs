using LightsOutGame.Sheared.Common.Models;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LightsOutGame.Client.App
{
    public class ApiCallHelper
    {
        public static string baseUri = "https://localhost:5001";

        public static async Task<TResponse> GetAsync<TResponse>(string method, string token = "", Dictionary<string, string> request = null)
        {
            TResponse response = default;

            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            using (HttpClient client = new HttpClient(httpClientHandler))
            {

                client.BaseAddress = new Uri(baseUri);
                if (request == null)
                    request = new Dictionary<string, string>();

                MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                }
                HttpResponseMessage result = await client.GetAsync(QueryHelpers.AddQueryString(method, request));
                string stringData = await result.Content.ReadAsStringAsync();
                if (result.IsSuccessStatusCode)
                {
                    if (!string.IsNullOrEmpty(stringData))
                    {
                        var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm:ss" };
                        response = JsonConvert.DeserializeObject<TResponse>(stringData, dateTimeConverter);
                    }
                }
                else
                {
                    if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        if (!string.IsNullOrEmpty(stringData))
                        {
                            var tmpRes = new SettingResponse();
                            response = JsonConvert.DeserializeObject<TResponse>(JsonConvert.SerializeObject(tmpRes));
                        }
                    }
                }

                return response;

            }

        }

        public static async Task<TResponse> PostAsync<TResponse, TRequest>(string method, TRequest request, string token)
        {
            TResponse response = default;
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            try
            {
                using (HttpClient client = new HttpClient(httpClientHandler))
                {
                    client.BaseAddress = new Uri(baseUri);

                    MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);
                    if (!string.IsNullOrEmpty(token))
                    {
                        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
                    }
                    HttpResponseMessage result = await client.PostAsync(method, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
                    string stringData = await result.Content.ReadAsStringAsync();
                    if (result.IsSuccessStatusCode)
                    {
                        if (!string.IsNullOrEmpty(stringData))
                        {
                            var dateTimeConverter = new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy HH:mm:ss" };
                            response = JsonConvert.DeserializeObject<TResponse>(stringData, dateTimeConverter);
                        }
                    }
                    else
                    {
                        if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            if (!string.IsNullOrEmpty(stringData))
                            {
                                var tmpRes = new SettingResponse();
                                response = JsonConvert.DeserializeObject<TResponse>(JsonConvert.SerializeObject(tmpRes));
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return response;

        }
    }
}
