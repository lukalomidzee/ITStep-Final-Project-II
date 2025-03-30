namespace CarRentalApplication.Models.Entities.Cars
{
    public class CarImage
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
    }
}
