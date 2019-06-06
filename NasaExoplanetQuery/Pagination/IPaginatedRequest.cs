namespace NasaExoplanetQuery.Pagination
{
    public interface IPaginatedRequest<T>
    {
        int TotalNumberOfRecords { get; }

        int NumberOfRecords { get; }

        int PageNumber { get; }
    }
}
