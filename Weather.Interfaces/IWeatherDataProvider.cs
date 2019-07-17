using System.Collections.Generic;
using System.Threading.Tasks;
using Weather.Contracts;

namespace Weather.Interfaces
{
    public interface IWeatherDataProvider
    {
        Task<WeatherTown> GetAsync(TownRequest town);
        IEnumerable<WeatherTown> GetAll();
    }
}
