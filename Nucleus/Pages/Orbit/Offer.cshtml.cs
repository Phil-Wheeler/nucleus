using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nucleus.Data;
using Nucleus.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Nucleus.Pages.Orbit
{
    public class OfferModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        
        public OfferModel(ApplicationDbContext context)
        {
            _context = context;
            Input = new OfferViewModel();
        }

        public ICollection<Offer> Offers { get; private set; }
        public ICollection<Track> Tracks { get; private set; }

        public Credit Credit { get; set; }


        [BindProperty]
        public OfferViewModel Input { get; set; }

        public Guid CurrentUser { get { return Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value); } }


        public void OnGet(Guid? id)
        {
            Offers = _context.Offers
                .Include(t => t.Track)
                .Where(o => o.Member == CurrentUser)
                .ToList();

            Tracks = _context.Tracks.ToList();

            Credit = new Credit();
            Input.Credit = Credit;

            if (id.HasValue)
            {
                var selectedOffer  = _context.Offers
                    .Include(o => o.Track)
                    .SingleOrDefault(o => o.Id == id.Value);
                TempData["Editing"] = selectedOffer;
                Input.Offer = selectedOffer;
                Input.Tracks = Tracks;
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {
                if (Input.Offer.Id == Guid.Empty)
                {
                    Offer offer = Input.Offer;
                    offer.Member = CurrentUser;
                    _context.Offers.Add(offer);
                }
                else
                {
                    _context.Offers.Append(Input.Offer);
                }
                _context.SaveChanges();
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                // var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                // if (result.Succeeded)
                // {
                //     _logger.LogInformation("User logged in.");
                //     return LocalRedirect(Url.GetLocalUrl(returnUrl));
                // }
                // if (result.RequiresTwoFactor)
                // {
                //     return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                // }
                // if (result.IsLockedOut)
                // {
                //     _logger.LogWarning("User account locked out.");
                //     return RedirectToPage("./Lockout");
                // }
                // else
                // {
                //     ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                //     return Page();
                // }
                return RedirectToPage("Index");
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

    }

    public class OfferViewModel
    {
        public Offer Offer { get; set; }
        public IEnumerable<Track> Tracks { get; set; }

        public Credit Credit { get; set; }
    }
}
