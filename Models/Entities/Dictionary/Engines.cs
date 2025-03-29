using CarRentalApplication.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Models.Entities.Dictionary
{
    public class Engines : ISelector<float>
    {
        public int Id { get; set; }

        [Range(0, 10)]
        public float Value { get; set; }
    }
}
