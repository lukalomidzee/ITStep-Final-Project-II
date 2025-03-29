using CarRentalApplication.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Models.Entities.Dictionary
{
    public class FuelCapacities : ISelector<float>
    {
        public int Id { get; set; }

        [Range(0, 100)]
        public float Value { get; set; }
    }
}
