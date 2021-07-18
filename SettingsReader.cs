using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AudenAssessment
{
    public class SettingsReader
    {
        private static IConfigurationRoot config { get; set; }

        private static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Settings.json");

            config = builder.Build();

            return config;
        }

        public static Uri audenUrl = new Uri(
            GetConfiguration().GetSection("Url:Auden").Value);
    }
}
