using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Contracts
{
    public static class WeatherTownConverter
    {
        public static WeatherForecast ToForecast(this WeatherTown town)
        {
            return new WeatherForecast
            {
                Name = town.Name,
                TemperatureF = town.Temp
            };
        }
    }
}
