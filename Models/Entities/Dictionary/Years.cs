using CarRentalApplication.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApplication.Models.Entities.Dictionary
{
    public class Years : ISelector<int>
    {
        public int Id { get; set; }

        [Range(1900, 2025)]
        public int Value { get; set; }
    }
}
