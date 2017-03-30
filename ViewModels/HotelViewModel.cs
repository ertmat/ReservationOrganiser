using ReservationOrganiser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationOrganiser.ViewModels
{
    public class HotelViewModel
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }
        public int CalendarId { get; set; }

        public int Status { get; set; }

        public string Name { get; set; }

        public IEnumerable<Room> Rooms { get; set; }
    }
}
