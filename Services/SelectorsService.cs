using CarRentalApplication.Interfaces;
using CarRentalApplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApplication.Services
{
    public class SelectorsService : ISelectorsService
    {
        private readonly ApplicationDbContext _context;

        public SelectorsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<IEnumerable<SelectListItem>>> GetAllSelectors()
        {
            return new List<IEnumerable<SelectListItem>>
            {
                await GetCarCities(),
                await GetCarColors(),
                await GetCarEngines(),
                await GetCarFuelCapacities(),
                await GetCarGearboxes(),
                await GetCarSeats(),
                await GetCarYears()
            };

            //var selectorValues = new List<IEnumerable<SelectListItem>>
            //{
            //    cities = await GetCarCities(),
            //    colors = await GetCarColors(),
            //    engines = await GetCarEngines(),
            //    fuelCapacities = await GetCarFuelCapacities(),
            //    gearboxes = await GetCarGearboxes(),
            //    seats = await GetCarSeats(),
            //    years = await GetCarYears()
            //};

            //return selectorValues;

        }


        public async Task<IEnumerable<SelectListItem>> GetCarCities()
        {
            return await _context.Cities.Select(x => new SelectListItem
            {
                Text = x.Value,
                Value = x.Id.ToString()
                //Value = x.Id.ToString()

            }).ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetCarColors()
        {
            return await _context.Colors.Select(x => new SelectListItem
            {
                Text = x.Value,
                Value = x.Id.ToString()
            }).ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetCarEngines()
        {
            return await _context.Engines.Select(x => new SelectListItem
            {
                Text = x.Value.ToString(),
                Value = x.Id.ToString()
            }).ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetCarFuelCapacities()
        {
            return await _context.FuelCapacities.Select(x => new SelectListItem
            {
                Text = x.Value.ToString(),
                Value = x.Id.ToString()
            }).ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetCarGearboxes()
        {
            return await _context.Gearboxes.Select(x => new SelectListItem
            {
                Text = x.Value,
                Value = x.Id.ToString()
            }).ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetCarSeats()
        {
            return await _context.Seats.Select(x => new SelectListItem
            {
                Text = x.Value.ToString(),
                Value = x.Id.ToString()
            }).ToListAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetCarYears()
        {
            return await _context.Years.Select(x => new SelectListItem
            {   
                Text = x.Value.ToString(),
                Value = x.Id.ToString()
            }).ToListAsync();
        }
    }
}
