using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebProgramlama.Data;
using WebProgramlama.Models;

namespace WebProgramlama.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ApiController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Ucus> Get()
        {
            return _context.Ucuslar.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Ucus Get(int id)
        {
            return _context.Ucuslar.Where(u => u.UcusId == id).FirstOrDefault();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Ucus value)
        {
            _context.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var querry = _context.Ucuslar.Where(u => u.UcusId == id).FirstOrDefault();
            if (querry != null)
            {
                _context.Remove(_context.Ucuslar.Where(u => u.UcusId == id).FirstOrDefault());
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}