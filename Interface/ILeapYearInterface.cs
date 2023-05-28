using Leap_Year.Data;

namespace Leap_Year.Interface
{
    public interface ILeapYearInterface
    {
        public IQueryable<LeapYear> GetActiveUsers();
        public string GetLeapYearInfo();
        public void AddAndSave(LeapYear LeapYear);
    }
}
