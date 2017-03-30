using System.Collections.Generic;

namespace ReservationOrganiser.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public int OriginId { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string jsonData { get; set; }

        public int CalendarId { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}