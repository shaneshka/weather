using System;
using Microsoft.Extensions.Configuration;
using Weather.Interfaces;

namespace Weather.Settings
{
    public class WeatherSettings : IWeatherSettings
    {
        private readonly IConfiguration _configuration;
        private string GetKey => _configuration.GetValue<string>("Weather:key");
        string IWeatherSettings.GetBaseUrl() => _configuration.GetValue<string>("Weather:url");
        public string GetUrl(string townName) => $"/data/2.5/weather?q={townName}&appid={GetKey}";
        TimeSpan IWeatherSettings.GetExpireCache() => TimeSpan.Parse(_configuration.GetValue<string>("Weather:expire"));

        (TimeSpan dieTime, TimeSpan period) IWeatherSettings.GetDataUpdate() => (
            TimeSpan.Parse(_configuration.GetValue<string>("Weather:DataUpdate:dueTime")),
            TimeSpan.Parse(_configuration.GetValue<string>("Weather:DataUpdate:period")));

        public WeatherSettings(IConfiguration config)
        {
            _configuration = config;
        }
    }
}
