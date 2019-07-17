using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Contracts;
using Weather.Interfaces;

namespace Weather.Storage
{
    public class WeatherStorage : IWeatherStorage
    {

        private ConcurrentDictionary<string, WeatherTown> _weathers = new ConcurrentDictionary<string, WeatherTown>();

        public WeatherStorage()
        {
            Init();
        }

        private void Init()
        {
            Create(new WeatherTown
            {
                Name = "London"
            });
        }

        public WeatherTown Get(string name)
        {
            _weathers.TryGetValue(name, out WeatherTown weatherTown);
            return weatherTown;
        }

        public WeatherTown Create(WeatherTown town)
        {
            if (!_weathers.TryGetValue(town.Name, out WeatherTown weatherTown))
            {
                weatherTown = town;
                _weathers.TryAdd(town.Name, weatherTown);
            }

            return weatherTown;
        }

        public WeatherTown Update(WeatherTown town)
        {
            if (_weathers.TryGetValue(town.Name, out WeatherTown weatherTown))
            {
                weatherTown.Temp = town.Temp;
            }

            return weatherTown;
        }

        public IEnumerable<WeatherTown> GetAll()
        {
            return _weathers.Values;
        }
    }
}
