using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practice_Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace practice_Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ExampleController : ControllerBase
    {
        [HttpGet]
        public IActionResult Test()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Test1()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Test2()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Test3()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<string> students = new List<string>() { "Nisa", "Tunzale", "Arzu" };

            return Ok(students);
            
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            return Ok(id + " this is id");
        }

        [HttpGet]
        public IActionResult Search([FromQuery] string? searchText, [FromQuery] int id, [FromQuery] string userId)
        {
            return Ok(searchText + " " + id + " " + userId);
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            return Ok(user.Name + " " + user.Surname);
        }

    }
}

