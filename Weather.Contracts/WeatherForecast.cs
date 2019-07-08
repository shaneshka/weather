using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Contracts
{
    public class WeatherForecast
    {
        public string Name { get; set; }
        public string DateFormatted { get; set; }
        public double TemperatureC => (TemperatureF - 32) * 5/9;
        public string Summary { get; set; }

        public double TemperatureF { get; set; }
    }
}
