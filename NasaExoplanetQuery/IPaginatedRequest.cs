namespace NasaExoplanetQuery
{
    public interface IPaginatedRequest<T>
    {
        int TotalNumberOfRecords { get; }

        int NumberOfRecords { get; }

        int PageNumber { get; }
    }
}
