namespace NasaExoplanetQuery
{
    using System.Collections.Generic;

    using NasaExoplanetQuery.Model;

    public interface IPlanets
    {
        IEnumerable<Planet> Planets { get; }
    }
}
