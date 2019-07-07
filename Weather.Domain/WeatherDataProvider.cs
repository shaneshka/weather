using System;
using System.Threading.Tasks;
using Weather.Contracts;
using Weather.Interfaces;

namespace Weather.Domain
{
    public class WeatherDataProvider : IWeatherDataProvider
    {
        private readonly IWeatherHttpClient _weatherHttpClient;
        private readonly IWeatherStorage _weatherStorage;
        private readonly IWeatherDataUpdater _dataUpdater;

        public WeatherDataProvider(IWeatherHttpClient httpClient, IWeatherStorage weatherStorage,
            IWeatherDataUpdater dataUpdater)
        {
            _weatherHttpClient = httpClient;
            _weatherStorage = weatherStorage;
            _dataUpdater = dataUpdater;

            _dataUpdater.StartTimer();
        }

        public async Task<WeatherTown> GetAsync(TownRequest town)
        {
            var weatherTown = await _weatherStorage.GetAsync(town.Name);
            if (weatherTown == null)
            {
                weatherTown = await GetWeather(town);

                await _weatherStorage.CreateAsync(weatherTown);
            }

            return weatherTown;
        }

        private async Task<WeatherTown> GetWeather(TownRequest town)
        {
            return await _weatherHttpClient.GetAsync(town.Name);
        }
    }
}
