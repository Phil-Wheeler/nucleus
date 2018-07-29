﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NucleusApi.Models;
using NucleusApi.Data;

using MongoDB.Driver;
using MongoDB.Bson;

namespace NucleusApi.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private readonly ApiContext _context;


        public PostsController(IOptions<Settings> Settings)
        {
            _context = new ApiContext(Settings);
        }


        // GET api/Posts
        [HttpGet]
        public JsonResult Get()
        {
            if (_context.Posts.CountDocuments(new BsonDocument()) == 0)
            {
<<<<<<< HEAD
                _context.Posts.InsertOne(new Post { Id = Guid.NewGuid(), Title = "Test Post", Owner = Guid.NewGuid() });
            }
            
            var result = _context.Posts.Find(_ => true).ToList();
            return result;
=======
                _context.Posts.Add(new Post { Id = Guid.NewGuid(), Title = "Test Post", Owner = Guid.NewGuid(), PostType = PostType.Request, Created = DateTime.Now });
                _context.SaveChanges();
            }
            return new JsonResult(new { posts = _context.Posts });// _context.Posts;
>>>>>>> e9c1b4e3645272b3f77018da4041525a969eea11
        }

        // GET api/Posts/5
        [HttpGet("{id}")]
        public ActionResult<Post> Get(string id)
        {
            ObjectId internalId = GetInternalId(id);

            var result = _context.Posts.Find(x => x.InternalId == internalId || x.Id == Guid.Parse(id));

            if (result == null)
            {
                return NotFound();
            }
            return result.First();
        }

        // POST api/Posts
        [HttpPost]
        public void Post([FromBody] Post post)
        {
            post.Id = Guid.NewGuid();
            _context.Posts.InsertOne(post);
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


        private ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }
    }
}
