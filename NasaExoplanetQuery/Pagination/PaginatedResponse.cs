namespace NasaExoplanetQuery.Pagination
{
    using System.Collections.Generic;

    public class PaginatedResponse<T> : IPaginatedResponse<T>
    {
        public IEnumerable<T> Data { get; set; }

        public int TotalNumberOfRecords { get; set; }
    }
}
