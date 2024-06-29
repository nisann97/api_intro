using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practice_Api.Data;
using practice_Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace practice_Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {

        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var existData = await _context.Categories.FindAsync(id);

            if (existData is null) return NotFound();
            return Ok(existData);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int? id)
        {
            if (id is null) return BadRequest();
            var existData = await _context.Categories.FindAsync(id);
            if (existData is null) return NotFound();

            _context.Categories.Remove(existData);

            await _context.SaveChangesAsync();
            return Ok();


        }



    }
}

