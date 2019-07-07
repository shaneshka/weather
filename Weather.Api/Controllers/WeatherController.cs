using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Weather.Contracts;
using Weather.Errors;
using Weather.Interfaces;

namespace Weather.Api.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherDataProvider _dataProvider;

        public WeatherController(IWeatherDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        [HttpGet]
        
        public async Task<ActionResult<WeatherTown>> Get([FromQuery] TownRequest town)
        {
            if (town == null || string.IsNullOrEmpty(town.Name))
            {
                return BadRequest("укажите город");
            }

            try
            {
                var result = await _dataProvider.GetAsync(town);

                return Ok(result);
            }
            catch (WeatherException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}