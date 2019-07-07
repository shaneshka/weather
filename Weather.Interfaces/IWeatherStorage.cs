using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Contracts;

namespace Weather.Interfaces
{
    public interface IWeatherStorage
    {
        Task<WeatherTown> GetAsync(string name);
        Task<WeatherTown> CreateAsync(WeatherTown weatherTown);
        Task<WeatherTown> UpdateAsync(WeatherTown weatherTown);
        Task<IEnumerable<WeatherTown>> GetAllAsync();
    }
}
