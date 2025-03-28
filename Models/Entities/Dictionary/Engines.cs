using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Models.Entities.Dictionary
{
    public class Engines
    {
        public int Id { get; set; }

        [Range(0, 10)]
        public float EngineCapacity { get; set; }
    }
}
