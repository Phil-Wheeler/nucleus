using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NucleusApi.Models;
using NucleusApi.Data;


namespace NucleusApi.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly ApiContext _context;


        public PostsController(ApiContext ApiContext)
        {
            _context = ApiContext;
        }


        // GET api/Posts
        [HttpGet]
        public ActionResult<IEnumerable<Post>> Get()
        {
            if (_context.Posts.Count() == 0)
            {
                _context.Posts.Add(new Post { Id = Guid.NewGuid().ToString(), Title = "Test Post" });
                _context.SaveChanges();
            }
            return _context.Posts;
        }

        // GET api/Posts/5
        [HttpGet("{id}")]
        public ActionResult<Post> Get(Guid id)
        {
            var result = _context.Posts.Find(id);

            if (result == null)
            {
                return NotFound();
            }
            return result;
        }

        // POST api/Posts
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/Posts/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/Posts/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
