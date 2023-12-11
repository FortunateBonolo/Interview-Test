using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterviewTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private Hero[] heroes = new Hero[]
        {
            new Hero()
            {
                name= "Hulk",
                power="Strength from gamma radiation",
                stats= new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>( "strength", 5000 ),
                    new KeyValuePair<string, int>( "intelligence", 50),
                    new KeyValuePair<string, int>( "stamina", 2500 )
                }
            }
        };

        // GET: api/Heroes
        [HttpGet]
        public IEnumerable<Hero> Get()
        {
            return heroes;
        }

        // GET: api/Heroes/5
        [HttpGet("{id}", Name = "Get")]
        public Hero Get(int id)
        {
            return heroes.FirstOrDefault();
        }

        // POST: api/Heroes
        [HttpPost]
        public IActionResult Post([FromBody] string value, [FromQuery] string action = "none")
        {
            if (action.ToLower() == "evolve")
            {
                // Evolve the hero and return the updated hero
                heroes[0].evolve();
                return Ok(heroes[0]);
            }
            else
            {
                // Handle other actions or default behavior
                return BadRequest("Invalid action parameter");
            }
        }

        // PUT: api/Heroes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            // Update hero logic if needed
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            // Delete hero logic if needed
        }
    }
}