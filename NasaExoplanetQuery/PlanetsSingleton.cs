namespace NasaExoplanetQuery
{
    using System.Collections.Generic;

    using NasaExoplanetQuery.Model;

    public class PlanetsSingleton : IPlanets
    {
        private readonly IEnumerable<Planet> _planets;

        public IEnumerable<Planet> Planets => _planets;

        public PlanetsSingleton(IEnumerable<Planet> planets)
        {
            this._planets = planets;
        }
    }
}
