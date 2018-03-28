using System.Collections.Generic;
using System.Linq;
using IdeaApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdeaApi.Controllers
{
    [Route("api/[controller]")]
    public class IdeaController : Controller
    {
        private readonly IdeaContext _context;

        public IdeaController(IdeaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Idea> GetAll()
        {

            return _context.Ideas.ToList();
        }

        [HttpGet("{id}", Name = "GetIdea")]
        public IActionResult GetById(long id)
        {

            var idea = _context.Ideas.FirstOrDefault(c => c.Id == id);
            if (idea == null)
            {
                return NotFound();
            }
            return new ObjectResult(idea);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Idea item)
        {

            if (item == null)
            {
                return BadRequest();
            }

            _context.Ideas.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetIdea", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Idea item)
        {

            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var idea = _context.Ideas.FirstOrDefault(c => c.Id == id);
            if (idea == null)
            {
                return NotFound();
            }

            idea.Name = item.Name;
            idea.Status = item.Status;
            idea.Description = item.Description;

            _context.Ideas.Update(idea);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {

            var idea = _context.Ideas.FirstOrDefault(c => c.Id == id);
            if (idea == null)
            {
                return NotFound();
            }

            _context.Ideas.Remove(idea);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
