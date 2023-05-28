using Leap_Year.Data;
using Leap_Year.Interface;
using System.Security.Claims;

namespace Leap_Year.Services
{
    public class LeapYearService : ILeapYearInterface
    {
        private readonly ApplicationDbContext _context;
        public LeapYear LeapYear { get; set; } = default!;
        public LeapYearService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string GetLeapYearInfo()
        {
            if ((LeapYear.Year % 400 == 0))
            {
                LeapYear.Result = "Rok przystepny";
                return LeapYear.Result;
            }
            else if (LeapYear.Year % 100 == 0)
            {
                LeapYear.Result = "Rok nie jest przystepny";
                return LeapYear.Result;
            }

            else if (LeapYear.Year % 4 == 0)
            {
                LeapYear.Result = "Rok przystepny";
                return LeapYear.Result;
            }
            else
            {
                LeapYear.Result = "Rok nie jest przystepny";
                return LeapYear.Result;
            }
        }

        public void AddAndSave(LeapYear LeapYear)
        {
            _context.LeapYear.Add(LeapYear);
            _context.SaveChanges();
        }
        public IQueryable<LeapYear> GetActiveUsers()
        {
            return from s in _context.LeapYear select s;
        }
    }
}
