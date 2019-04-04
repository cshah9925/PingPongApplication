using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PingPongWebApplication.Models;

namespace PingPongWebApplication.Controllers
{
    /// <summary>
    /// Home Controller is responsible for operations performed on home page.
    /// It fetches data using the data context.
    /// </summary>
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        static DataContext db;
        public HomeController(DataContext dataContext)
        {
            db = dataContext;
        }
        
        [HttpGet("[action]")]
        public IEnumerable<Players> Index()
        {
            return db.Players.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Players Get(int id)
        {
            return db.Players.FirstOrDefault(p => p.Id == id);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Players player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // return validation error if email already exists
            Players existingPlayers = db.Players.Where(p => p.Email == player.Email).FirstOrDefault();
            if (existingPlayers != null)
            {
                ModelState.AddModelError("Email", "This email already exists");
                return BadRequest(ModelState);
            }

            db.Players.Add(player);
            db.SaveChanges();
            return CreatedAtAction("Get", new { id = player.Id }, player);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Players player)
        {
            Players p = db.Players.FirstOrDefault(q => q.Id == id);
            p.FirstName = player.FirstName;
            p.LastName = player.LastName;
            p.Age = player.Age;
            p.SkillLevel = player.SkillLevel;
            p.Email = player.Email;
            p.ModifiedOn = DateTime.Now;
            db.SaveChanges();
            return CreatedAtAction("Get", new { id = id }, player);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Players player = db.Players.FirstOrDefault(r => r.Id == id);

            if (player != null)
            {
                db.Players.Remove(player);
                db.SaveChanges();
            }
        }
    }
}
