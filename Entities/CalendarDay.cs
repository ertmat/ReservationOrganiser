using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationOrganiser.Entities
{
    public class CalendarDay
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public int Month { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int CalendarId { get; set; }
        public bool Boocked { get; set; }
    }
}
