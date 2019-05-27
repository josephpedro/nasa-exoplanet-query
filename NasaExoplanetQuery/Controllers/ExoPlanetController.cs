namespace NasaExoplanetQuery.Controllers
{
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
        public IPaginatedResponse<Planet> GetAll([FromQuery] int pageNumber, [FromQuery] int numberOfRecords)
        {
            var skip = numberOfRecords * (pageNumber - 1);
            return new PaginatedResponse<Planet>
            {
                Data = this._planets.Planets.Skip(skip).Take(numberOfRecords),
                TotalNumberOfRecords = this._planets.Planets.Count()
            };
        }
    }
}
