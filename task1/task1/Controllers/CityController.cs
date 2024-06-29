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
    public class CityController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICityService _cityService;
        public CityController(AppDbContext context,
            ICityService cityService)
        {
            _context = context;
            _cityService = cityService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Cities.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] City city)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _cityService.CreateAsync(city);

            return CreatedAtAction(nameof(Create), city);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var existData = await _cityService.GetByIdAsync(id);

            if (existData is null) return NotFound();
            return Ok(existData);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id is null) return BadRequest();
            var existData = await _context.Cities.FindAsync(id);
            if (existData is null) return NotFound();

            _cityService.DeleteAsync(existData);

            return Ok();

        }

    }
}

