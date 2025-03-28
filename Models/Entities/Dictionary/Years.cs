using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Models.Entities.Dictionary
{
    public class Years
    {
        public int Id { get; set; }

        [Range(1900, 2025)]
        public int Year { get; set; }
    }
}
