using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using task1.Models;

namespace task1.Services.Interfaces
{
	public interface ICountryService
	{
        Task<List<Country>> GetAll();
        Task<bool> ExistAsync(string name);
        Task<SelectList> GetALlBySelectedAsync();
        Task CreateAsync(Country country);
        Task<Country> GetWithCityAsync(int id);
        Task<Country> GetByIdAsync(int id);
        Task DeleteAsync(Country country);
        Task EditAsync(Country country, Country newCountry);
    }
}

