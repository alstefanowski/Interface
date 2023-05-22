using Leap_Year.Data;
using Leap_Year.Interface;

namespace Leap_Year.Services
{
    public class LeapYearService: ILeapYearInterface
    {
        private readonly ApplicationDbContext _context;
        public LeapYear LeapYear { get; set; } = default!;
        public LeapYearService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<LeapYear> GetActiveUsers()
        {
            return from s in _context.LeapYear select s;
        }
    }
}
