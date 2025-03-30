using CarRentalApplication.Models.Entities.Cars;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Models.VMs.Cars
{
    public class ListCarViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string Engine { get; set; }
        public string Gearbox { get; set; }
        public double FuelCapacity { get; set; }
        public int Seats { get; set; }
        public string City { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public decimal Price { get; set; }
        public string CreatorPhoneNummber { get; set; }
        public int LikeCount { get; set; }
        public int Status { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
