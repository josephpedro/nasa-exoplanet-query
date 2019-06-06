namespace NasaExoplanetQuery.Pagination
{
    using System.Collections.Generic;

    public interface IPaginatedResponse<T>
    {
        IEnumerable<T> Data { get; set; }
    }
}
