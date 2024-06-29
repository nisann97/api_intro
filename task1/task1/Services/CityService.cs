using System;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using task1.Data;
using task1.Models;
using task1.Services.Interfaces;

namespace task1.Services
{
    public class CityService : ICityService
    {

        private readonly AppDbContext _context;

        public CityService(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(City city)
        {
            await _context.Cities.AddAsync(new City { Name = city.Name });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(City city)
        {
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(City city, City newCity)
        {
            city.Name = newCity.Name;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Cities.AnyAsync(m => m.Name.Trim() == name.Trim());
        }

        public async Task<List<City>> GetAll()
        {
            return await _context.Cities.ToListAsync();
        }

        public Task<SelectList> GetALlBySelectedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await _context.Cities.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public Task<City> GetWithCityAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

