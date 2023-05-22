using Leap_Year.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Leap_Year.Interface;

namespace Leap_Year.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILeapYearInterface _personService;

        [BindProperty]
        public LeapYear LeapYear { get; set; }
        public IQueryable<LeapYear> Records { get; set; }
        public IndexModel(ApplicationDbContext context, ILeapYearInterface personService)
        {
            _dbContext = context;
            _personService = personService;
        }

        [AllowAnonymous]
        public IActionResult OnPost()
        {
            if ((LeapYear.Year % 400 == 0))
            {
                LeapYear.Result = "Rok przystepny";
            }
            else if (LeapYear.Year % 100 == 0)
            {
                LeapYear.Result = "Rok nie jest przystepny";
            }

            else if (LeapYear.Year % 4 == 0)
            {
                LeapYear.Result = "Rok przystepny";
            }
            else
            {
                LeapYear.Result = "Rok nie jest przystepny";
            }
            LeapYear.EmailAddress = User.FindFirstValue(ClaimTypes.Email);
            if(LeapYear.EmailAddress == null)
            {
                LeapYear.EmailAddress = "brak";
            }
            LeapYear.IdAddress = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(LeapYear.IdAddress == null)
            {
                LeapYear.IdAddress = "brak";
            }
            LeapYear.SearchTime = DateTime.Now;
            _dbContext.LeapYear.Add(LeapYear);
            _dbContext.SaveChanges();
            Records = _personService.GetActiveUsers();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }
        public void OnGet()
        {
            Records = _personService.GetActiveUsers();
        }
    }
}