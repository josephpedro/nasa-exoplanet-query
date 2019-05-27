namespace NasaExoplanetQuery.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    using NasaExoplanetQuery.Model;

    [Route("api/[controller]")]
    public class ExoPlanetController : Controller
    {
        private readonly IPlanets _planets;
        public ExoPlanetController(IPlanets planets)
        {
            this._planets = planets;
        }

        [HttpGet("[action]")]
        public IEnumerable<Planet> GetAll([FromQuery] int start = 0)
        {
            return this._planets.Planets.Skip(start).Take(10);
        }
    }
}
