using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Model;
using Service.Interface;

namespace Passengers.Pages
{
    public class IndexModel(IPassengerService passengerService) : PageModel
    {
        [BindProperty]
        public IFormFile? CsvFile { get; set; }
        [BindProperty]
        public int? ClassFilter { get; set; }
        [BindProperty]
        public string? SexFilter { get; set; }
        [BindProperty]
        public int? MinAgeFilter { get; set; }
        [BindProperty]
        public int? MaxAgeFilter { get; set; }

        public PassengerStatistics? PassengerStatistics { get; set; }

        public IActionResult OnPostAsync()
        {
            if (CsvFile is null || CsvFile.Length == 0)
            {
                ModelState.AddModelError("CsvFile", "Please upload a CSV file.");
                return Page();
            }

            using (Stream stream = CsvFile.OpenReadStream())
            {
                PassengerStatistics = passengerService.ProcessCsvAsync(stream, ClassFilter, SexFilter, MinAgeFilter, MaxAgeFilter);
            }

            return Page();
        }
    }
}