using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nucleus.Models;
using Nucleus.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Nucleus.Controllers
{
    [Produces("application/json")]
    [Route("api/Offer")]
    [Authorize]
    public class OfferController : Controller
    {
        private readonly ApplicationDbContext _context;


        public OfferController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        // GET: api/Offer
        [HttpGet]
        public IEnumerable<Offer> Get()
        {
            return _context
                .Offers
                .Include(o => o.Track)
                .Include(o => o.Credits)
                .Where(o => o.Member == Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                .ToList();
        }

        // GET: api/Offer/5
        [HttpGet("{id}", Name = "Get")]
        public Offer Get(Guid id)
        {
            var model = _context
                .Offers
                .Include(o => o.Track)
                .Include(o => o.Credits)
                .FirstOrDefault(o => o.Id == id);

            model.Credits = new Credit() { Recurrence = Recurrence.Weekly, Unit = 1 };
            model.Track = new Track() { Name = "Testing" };

            return model;
        }
        
        // POST: api/Offer
        [HttpPost]
        public void Post([FromBody]Offer value)
        {
            var post = value;
        }
        
        // PUT: api/Offer/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Offer value)
        {
            var put = value;
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
