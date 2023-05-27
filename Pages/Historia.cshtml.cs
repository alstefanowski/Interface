using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;
using Leap_Year.Data;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Leap_Year.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.Caching.Distributed;
using Leap_Year.Interface;

namespace Leap_Year.Pages
{
    public class HistoriaModel : PageModel
    {
        private readonly Leap_Year.Data.ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly ILeapYearInterface _leapInterface;
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<LeapYear> leapYears { get; set; }
        public IQueryable<LeapYear> Records { get; set; }
        public HistoriaModel(Leap_Year.Data.ApplicationDbContext context, IConfiguration configuration, ILeapYearInterface leapInterface)
        {
            _context = context;
            _configuration = configuration;
            _leapInterface = leapInterface;
        }

        [BindProperty]
        public LeapYear LeapYear { get; set; } = default!;

        public async Task OnGetAsync(string currentFilter, string searchString, int? pageIndex)
        {
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            CurrentFilter = searchString;
            
            IQueryable<LeapYear> _LeapYear = from s in _context.LeapYear select s;
            Records = _leapInterface.GetActiveUsers();
            Records = Records.OrderByDescending(s => s.SearchTime);
            var pageSize = _configuration.GetValue("PageSize", 20);
            leapYears = await PaginatedList<LeapYear>.CreateAsync(
                Records.AsNoTracking(), pageIndex ?? 1, pageSize);
        }

    }
}
