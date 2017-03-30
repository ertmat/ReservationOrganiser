using System.Collections.Generic;

namespace ReservationOrganiser.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string OwnerId { get; set; }

        public int Status { get; set; }

        public string Name { get; set; }

        public IEnumerable<Room> Rooms { get; set; }
    }
}
