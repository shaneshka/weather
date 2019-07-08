using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Weather.Contracts;
using Weather.Errors;
using Weather.Interfaces;

namespace Weather.HttpClient
{
    public class WeatherHttpClient : IWeatherHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;
        private readonly IWeatherSettings _settings;

        public WeatherHttpClient(System.Net.Http.HttpClient httpClient, IWeatherSettings settings)
        {
            _httpClient = httpClient;
            _settings = settings;

            _httpClient.BaseAddress = new Uri(settings.GetBaseUrl());
        }

        public async Task<WeatherTown> GetAsync(string townName)
        {
            try
            {
                var w = await _httpClient.GetStringAsync(_settings.GetUrl(townName));
                var item = JsonConvert.DeserializeObject<Weather>(w);

                return new WeatherTown
                {
                    Name = item.Name,
                    Temp = item.Main.Temp
                };
            }
            catch (Exception e)
            {
                throw new WeatherException($"can not info for {townName}");
            }

        }

        class Weather
        {
            public string Name { get; set; }
            public WeatherMain Main { get; set; }
        }

        class WeatherMain
        {
            public double Temp { get; set; }
        }
    }
}
