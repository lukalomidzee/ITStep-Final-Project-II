﻿using CarRentalApplication.Interfaces;

namespace CarRentalApplication.Models.Entities.Dictionary
{
    public class Cities : ISelector<string>
    {
        public int Id { get; set; }

        public string Value { get; set; }
    }
}
