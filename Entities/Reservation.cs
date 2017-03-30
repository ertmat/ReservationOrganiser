using System;

namespace ReservationOrganiser.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int OriginId { get; set; }
        public int OriginHotelId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Guests { get; set; }
        public double Deposit { get; set; }
        public string jsonData { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
