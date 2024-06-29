using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using task1.Data;
using task1.Models;
using task1.Services.Interfaces;

namespace task1.Services
{
    public class CountryService : ICountryService
    {


        private readonly AppDbContext _context;

        public CountryService(AppDbContext context)
        {
            _context = context;
        }


        public async Task CreateAsync(Country country)
        {
            await _context.Countries.AddAsync(new Country { Name = country.Name });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Country country)
        {
             _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Country country, Country newCountry)
        {
            country.Name = newCountry.Name;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(string name)
        {
            return await _context.Countries.AnyAsync(m => m.Name.Trim() == name.Trim());
        }

        public async Task<List<Country>> GetAll()
        {
          return await _context.Countries.ToListAsync();
        }

        public Task<SelectList> GetALlBySelectedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await _context.Countries.Where(m => m.Id == id).FirstOrDefaultAsync();

        }

        public async Task<Country> GetWithCityAsync(int id)
        {
            return await _context.Countries.Where(m => m.Id == id).Include(m => m.Cities).FirstOrDefaultAsync();
        }
    }
}

