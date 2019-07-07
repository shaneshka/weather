using System;

namespace Weather.Interfaces
{
    public interface IWeatherSettings
    {
        string GetBaseUrl();
        string GetUrl(string townName);
        TimeSpan GetExpireCache();
        (TimeSpan dieTime, TimeSpan period) GetDataUpdate();
    }
}
