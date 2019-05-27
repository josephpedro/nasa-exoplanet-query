namespace NasaExoplanetQuery
{
    using System.Collections.Generic;

    public interface IPaginatedResponse<T>
    {
        IEnumerable<T> Data { get; set; }
    }
}
