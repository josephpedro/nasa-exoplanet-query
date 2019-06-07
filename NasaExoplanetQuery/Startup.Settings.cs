namespace NasaExoplanetQuery
{
    using Microsoft.Extensions.DependencyInjection;

    using NasaExoplanetQuery.Settings;

    public partial class Startup
    {
        private void ConfigureSettings(IServiceCollection services)
        {
            var settings = new SettingsResolver(this.Configuration);

            services.AddSingleton<ISettings>(settings);
            Settings.Settings.Current = settings;
        }
    }
}