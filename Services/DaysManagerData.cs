using ReservationOrganiser.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ReservationOrganiser.Services
{
    public interface IDaysManager
    {
        void Commit();
        IEnumerable<CalendarDay> GetDay(int calId, int week, int month);
        IEnumerable<CalendarDay> GetBooked();
        CalendarDay GetDayNumber(int number);
        CalendarDay GetDayForCalendar(int calId);
    }

    public class SQLDaysData : IDaysManager
    {
        private ReservationOrganizerDbContext _context;

        public SQLDaysData(ReservationOrganizerDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IEnumerable<CalendarDay> GetDay(int calId, int week, int month)
        {
            return _context.CalendarDays.Where(i => i.CalendarId == calId).Where(w => w.Week == week).Where(m => m.Month == month);
        }

        public IEnumerable<CalendarDay> GetBooked()
        {
            return _context.CalendarDays.Where(b => b.Boocked == true);
        }

        public CalendarDay GetDayNumber(int number)
        {
            return _context.CalendarDays.FirstOrDefault(n => n.Number == number);
        }

        public CalendarDay GetDayForCalendar(int calId)
        {
            return _context.CalendarDays.FirstOrDefault(i => i.CalendarId == calId);
        }

        public CalendarDay Add(CalendarDay newCalendarDay)
        {
            _context.CalendarDays.Add(newCalendarDay);
            return newCalendarDay;
        }

        
    }
}
