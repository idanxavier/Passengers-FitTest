using CsvHelper;
using CsvHelper.Configuration;
using Model;
using Service.Interface;
using System.Globalization;
using System.Text;

namespace Service.Implementation
{
    public class PassengerService : IPassengerService
    {
        public PassengerStatistics ProcessCsvAsync(Stream stream, int? classFilter, string? sexFilter, int? minAgeFilter, int? maxAgeFilter)
        {
            using var reader = new StreamReader(stream, Encoding.UTF8);
            using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
            csv.Context.RegisterClassMap<PassengerMap>();
            var passengers = csv.GetRecords<Passenger>().ToList();

            if (classFilter.HasValue)
                passengers = passengers.Where(p => p.Pclass == classFilter.Value).ToList();

            if (!string.IsNullOrEmpty(sexFilter))
                passengers = passengers.Where(p => p.Sex == sexFilter).ToList();

            if (minAgeFilter.HasValue)
                passengers = passengers.Where(p => p.Age >= minAgeFilter.Value).ToList();

            if (maxAgeFilter.HasValue)
                passengers = passengers.Where(p => p.Age <= maxAgeFilter.Value).ToList();

            var statistics = new PassengerStatistics
            {
                SurvivedCount = passengers.Count(p => p.Survived == 1),
                DiedCount = passengers.Count(p => p.Survived == 0),
                ClassCount = passengers.GroupBy(p => p.Pclass).ToDictionary(g => g.Key, g => g.Count()),
                MaleCount = passengers.Count(p => p.Sex == "male"),
                FemaleCount = passengers.Count(p => p.Sex == "female"),
                AverageAge = passengers.Average(p => p.Age)
            };

            return statistics;
        }
    }
}