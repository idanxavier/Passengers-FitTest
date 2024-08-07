using Model;

namespace Service.Interface
{
    public interface IPassengerService
    {
        PassengerStatistics ProcessCsvAsync(Stream stream, int? classFilter, string? sexFilter, int? minAgeFilter, int? maxAgeFilter);
    }
}
