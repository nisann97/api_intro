using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using task1.Models;

namespace task1.Services.Interfaces
{
	public interface ICityService
	{
		Task<List<City>> GetAll();
        Task<bool> ExistAsync(string name);
        Task<SelectList> GetALlBySelectedAsync();
        Task CreateAsync(City city);
        Task<City> GetWithCityAsync(int id);
        Task<City> GetByIdAsync(int id);
        Task DeleteAsync(City city);
        Task EditAsync(City city, City newCity);

    }
}

