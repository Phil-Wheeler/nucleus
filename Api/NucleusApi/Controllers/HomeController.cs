using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NucleusApi.Models;
using NucleusApi.Data;


namespace NucleusApi.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApiContext _context;


        public HomeController(ApiContext ApiContext)
        {
            _context = ApiContext;
        }

        public IActionResult Index()
        {
            return Redirect("/swagger");
        }
    }
}