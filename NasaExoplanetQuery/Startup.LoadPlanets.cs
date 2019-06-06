namespace NasaExoplanetQuery
{
    using System.Collections.Generic;
    using System.IO;

    using Microsoft.Extensions.DependencyInjection;

    using NasaExoplanetQuery.Model;

    public partial class Startup
    {
        private void LoadPlanetsIntoMemory(IServiceCollection services)
        {
            FileStream fileStream = new FileStream("Files/planets_2019.05.27_03.23.59.csv", FileMode.Open);
            List<Planet> _planets = new List<Planet>();
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line;
                do
                {
                    line = reader.ReadLine();
                    if (line?.StartsWith('#') ?? true) continue;
                    var split = line.Split(',');
                    _planets.Add(new Planet
                    {
                        pl_hostname = split[0],
                        pl_letter = split[1]
                    });
                } while (!string.IsNullOrWhiteSpace(line));
            }

            var planetsSingleton = new PlanetsSingleton(_planets);
            services.AddSingleton<IPlanets>(planetsSingleton);
        }
    }
}
