namespace NasaExoplanetQuery.Settings
{
    using System;

    using Microsoft.Extensions.Configuration;

    public class SettingsResolver : ISettings
    {
        private IConfigurationRoot configuration;

        public SettingsResolver(IConfigurationRoot configuration)
        {
            this.configuration = configuration ?? throw new ArgumentException("You need to send a valid configuration.");
        }

        public string OverviewPageLink()
        {
            return this.configuration["NasaExoplanetArchive:OverviewPageLink"];
        }
    }
}
