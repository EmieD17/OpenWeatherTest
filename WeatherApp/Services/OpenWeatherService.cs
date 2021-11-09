using OpenWeatherAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class OpenWeatherService : IWindDataService
    {
        private static OpenWeatherProcessor owp;
        public WindDataModel LastWindData;
        public OpenWeatherService(string apiKey)
        {
            owp = OpenWeatherProcessor.Instance;
            owp.ApiKey = apiKey;

        }

        public async Task<WindDataModel> GetDataAsync()
        {
            OWCurrentWeaterModel currentModel = await owp.GetCurrentWeatherAsync();

            WindDataModel wdm = new WindDataModel();

            wdm.DateTime = DateTime.UnixEpoch.AddSeconds(currentModel.DateTime);
            wdm.Direction = currentModel.Wind.Deg;
            wdm.MetrePerSec = currentModel.Wind.Speed;

            LastWindData = wdm;
            return wdm;
        }
    }
}
