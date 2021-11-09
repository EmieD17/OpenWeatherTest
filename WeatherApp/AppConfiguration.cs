using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    static public class AppConfiguration
    {
        private static IConfiguration configuration;

        public static string GetValue(string key)
        {
            if(configuration == null)
            {
                initConfig();
            }

            key = configuration["ApiKey"];
            return key;
        }
        private static void initConfig()
        {
            configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddUserSecrets("85259b01-2a57-4afb-8683-e3c798b4f681").Build();
        }
    }
}
