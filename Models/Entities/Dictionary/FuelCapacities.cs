using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Models.Entities.Dictionary
{
    public class FuelCapacities
    {
        public int Id { get; set; }

        [Range(0, 100)]
        public float FuelCapacity { get; set; }
    }
}
