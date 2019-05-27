using System.Collections.Generic;

namespace NasaExoplanetQuery
{
    public class PaginatedResponse<T> : IPaginatedResponse<T>
    {
        public IEnumerable<T> Data { get; set; }

        public int TotalNumberOfRecords { get; set; }
    }
}
