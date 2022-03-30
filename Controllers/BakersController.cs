using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DotnetBakery.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetBakery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BakersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public BakersController(ApplicationContext context) {
            _context = context;
        }
        // OUR API
        // GET All bakers
        [HttpGet]
        public IEnumerable<Baker> GetAll()
        {
            Console.WriteLine("get all bakers");
            // no SQL
            return _context.Bakers;
        }

        // GET 1 baker by id
        // GET /api/bakers/:id
        [HttpGet("{id}")]
        public ActionResult<Baker> GetById(int id)
        {
            Baker baker = _context.Bakers.SingleOrDefault(baker => baker.id == id);

            if (baker is null)
            {
                return NotFound(); // res.sendStatus(404)
            }

            return baker;
        }
        // POST - add a new baker
        [HttpPost]
        public IActionResult Post(Baker baker)
        {   // uses a transactions
            _context.Add(baker); // insert, not committed
            _context.SaveChanges();

           // return baker; // would be missing id

            // returns the url to /api/bakers?id=<new-id-number>
            return CreatedAtAction(nameof(Post),
                                     new {id = baker.id}, baker);
        }




        // Delete a baker by id
        // PUT - change a baker's name by id
        // stretch: Patch a baker by id

    }
}
