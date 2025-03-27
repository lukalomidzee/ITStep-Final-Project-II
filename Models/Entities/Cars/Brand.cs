namespace CarRentalApplication.Models.Entities.Cars
{
    public class Brand
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public List<Model> Models { get; set; } = new List<Model>();
    }
}
