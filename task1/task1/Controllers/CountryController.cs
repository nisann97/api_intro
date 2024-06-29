using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task1.Data;
using task1.Models;
using task1.Services;
using task1.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace task1.Controllers
{
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly ICountryService _countryService;
        public CountryController(AppDbContext context,
            ICountryService countryService)
        {
            _context = context;
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Country country)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), country);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var existData = await _countryService.GetByIdAsync(id);

            if (existData is null) return NotFound();
            return Ok(existData);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id is null) return BadRequest();
            var existData = await _context.Countries.FindAsync(id);
            if (existData is null) return NotFound();

            _countryService.DeleteAsync(existData);

            return Ok();

        }


    }
}

