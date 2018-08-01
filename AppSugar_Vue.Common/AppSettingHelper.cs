using Microsoft.Extensions.Configuration;
using System;

namespace AppSugar_Vue.Common
{
    public static class AppSettingHelper
    {
        public static IConfiguration Configuration(string configName)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(configName);

            IConfiguration configuration = builder.Build();

            return configuration;
        }
    }
}
