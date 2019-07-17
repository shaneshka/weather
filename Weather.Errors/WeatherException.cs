using System;

namespace Weather.Errors
{
    public class WeatherException : Exception
    {
        public WeatherException(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}
