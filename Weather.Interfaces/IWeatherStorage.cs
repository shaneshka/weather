using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Weather.Contracts;

namespace Weather.Interfaces
{
    public interface IWeatherStorage
    {
        WeatherTown Get(string name);
        WeatherTown Create(WeatherTown weatherTown);
        WeatherTown Update(WeatherTown weatherTown);
        IEnumerable<WeatherTown> GetAll();
    }
}
