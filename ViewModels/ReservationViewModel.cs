using ReservationOrganiser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationOrganiser.ViewModels
{
    public class ReservationViewModel
    {
        public Room ResRoom { get; set; }
        public int OriginId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int PricePer { get; set; }
        public double TotalPrice { get; set; }
        public double Deposit { get; set; }
        public double ToPay { get; set; }
        public int Guests { get; set; }

        public double TotalDays { get; set; }

        public Hotel SelectedHotel { get; set; }
        public IEnumerable<Hotel> Hotels { get; set; }
        public IEnumerable<Room> Rooms { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }

        public string jsonData { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
