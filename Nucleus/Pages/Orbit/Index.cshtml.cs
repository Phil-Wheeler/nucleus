using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nucleus.Data;
using Nucleus.Models;

namespace Nucleus.Pages.Orbit
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<Offer> Offers { get; private set; }
        public ICollection<Request> Requests { get; private set; }


        public void OnGet()
        {
            Offers = _context.Offers
                .Where(o => o.Member.UserName == User.Identity.Name)
                .ToList();

            Requests = _context.Requests
                .Where(r => r.Member.UserName == User.Identity.Name)
                .ToList();
        }
    }
}
