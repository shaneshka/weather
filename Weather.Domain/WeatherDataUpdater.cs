using System.Threading;
using Weather.Interfaces;

namespace Weather.Domain
{
    public class WeatherDataUpdater : IWeatherDataUpdater
    {
        private static Timer _timer;
        private readonly IWeatherStorage _weatherStorage;
        private readonly IWeatherHttpClient _httpClient;
        private readonly IWeatherSettings _settings;

        public WeatherDataUpdater(IWeatherSettings settings, IWeatherStorage weatherStorage, IWeatherHttpClient httpClient)
        {
            this._settings = settings;
            _weatherStorage = weatherStorage;
            _httpClient = httpClient;

        }

        public void StartTimer()
        {
            if (_timer == null)
            {
                _timer = new Timer(
                    callback: DataUpdateAsync,
                    state: null,
                    dueTime: (int)_settings.GetDataUpdate().dieTime.TotalMilliseconds,
                    period: (int)_settings.GetDataUpdate().period.TotalMilliseconds
                );
            }
        }

        private async void DataUpdateAsync(object state)
        {
            var weatherTowns = _weatherStorage.GetAll();

            foreach (var weatherTown in weatherTowns)
            {
                var weather = await _httpClient.GetAsync(weatherTown.Name);
                weatherTown.Temp = weather.Temp;

                _weatherStorage.Update(weatherTown);
                
            }
        }
    }
}
