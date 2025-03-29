using CarRentalApplication.Interfaces;

namespace CarRentalApplication.Models.Entities.Dictionary
{
    public class Seats : ISelector<int>
    {
        public int Id { get; set; }

        public int Value { get; set; }
    }
}
