namespace NasaExoplanetQuery.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Caching.Memory;

    using NasaExoplanetQuery.Model;

    [Route("api/[controller]")]
    public class ExoPlanetController : Controller
    {
        private readonly string _cacheKey = "{0}-{1}";

        private readonly IPlanets _planets;
        private readonly IMemoryCache _cache;

        public ExoPlanetController(IPlanets planets, IMemoryCache memoryCache)
        {
            this._planets = planets;
            this._cache = memoryCache;
        }

        [HttpGet("[action]")]
        public IPaginatedResponse<Planet> GetAll([FromQuery] int pageNumber, [FromQuery] int numberOfRecords)
        {
            var cacheKey = string.Format(this._cacheKey, pageNumber, numberOfRecords);

            List<Planet> cachedPlanets = null;
            // Look for cache key.
            if (!_cache.TryGetValue(cacheKey, out cachedPlanets))
            {
                // Key not in cache, so get data.
                var skip = numberOfRecords * (pageNumber - 1);

                var planets = this._planets.Planets.Skip(skip).Take(numberOfRecords);

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetAbsoluteExpiration(DateTimeOffset.MaxValue)
                    .SetPriority(CacheItemPriority.NeverRemove);

                // Save data in cache.
                _cache.Set(cacheKey, planets, cacheEntryOptions);

                return this.CreatePaginatedResponse(planets);
            }


            return this.CreatePaginatedResponse(cachedPlanets);
        }

        private PaginatedResponse<Planet> CreatePaginatedResponse(IEnumerable<Planet> planets)
        {
            return new PaginatedResponse<Planet>
            {
                Data = planets,
                TotalNumberOfRecords = this._planets.Planets.Count()
            };
        }
    }
}
