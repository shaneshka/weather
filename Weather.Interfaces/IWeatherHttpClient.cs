using System.Threading.Tasks;
using Weather.Contracts;

namespace Weather.Interfaces
{
    public interface IWeatherHttpClient
    {
        //Task<HttpResponseMessage> GetAsync(string requestUri);
        //Task<T> GetAsync<T>(string requestUri);
        Task<WeatherTown> GetAsync(string townName);
    }
}