using ReservationOrganiser.Entities;
using System.Collections.Generic;

namespace ReservationOrganiser.ViewModels
{
    public class DashboardViewModel
    {
        public string UserId { get; set; }
        public Hotel SelectedHotel { get; set; }
        public IEnumerable<Hotel> Hotels { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
