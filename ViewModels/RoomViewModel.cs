using ReservationOrganiser.Entities;
using System.Collections.Generic;

namespace ReservationOrganiser.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public int HotelId { get; set; }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int CalendarId { get; set; }
        public double TotalEarn { get; set; }


        public string jsonData { get; set; }

        public Hotel SelectedHotel { get; set; }
        public IEnumerable<Hotel> Hotels { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
