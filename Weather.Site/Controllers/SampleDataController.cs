using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather.Contracts;
using Weather.Errors;
using Weather.Interfaces;

namespace Weather.UI2.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private readonly IWeatherDataProvider _dataProvider;

        public SampleDataController(IWeatherDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        
        [HttpGet("[action]")]
        public async Task<IEnumerable<WeatherForecast>> WeatherForecasts([FromQuery] TownRequest town)
        {
            if (town == null || string.IsNullOrEmpty(town.Name))
            {
                return _dataProvider.GetAll()?.Select(x => x.ToForecast());
                //throw new Exception("укажиите город");
            }

            try
            {
                var weather = await _dataProvider.GetAsync(town);

                return new WeatherForecast[]
                {
                    weather.ToForecast()

                };
            }
            catch (WeatherException ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
