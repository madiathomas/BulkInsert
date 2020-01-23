using Microsoft.Extensions.Configuration;
using Recurso.BulkInsert.Sample.Common.Interfaces;
using System;

namespace Recurso.BulkInsert.Sample.DAL
{
    public class AppSettings : IAppSettings
    {
        public string GetSetting(string settingName)
        {
            string directory = System.IO.Directory.GetCurrentDirectory();
            string jsonFileName = "appsettings.json";

            var configurationRoot = new ConfigurationBuilder().SetBasePath(directory).AddJsonFile(jsonFileName).Build();

            return configurationRoot[$"AppSettings:{settingName}"];
        }
    }
}
