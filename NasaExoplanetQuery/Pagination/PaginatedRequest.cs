namespace NasaExoplanetQuery.Pagination
{
    public class PaginatedRequest<T> : IPaginatedRequest<T>
    {
        public int TotalNumberOfRecords { get; }

        public int NumberOfRecords { get; }

        public int PageNumber { get; }
    }
}
