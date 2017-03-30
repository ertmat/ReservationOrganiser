using ReservationOrganiser.Entities;
using ReservationOrganiser.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationManagerData.Services
{
    public interface IReservationManagerData
    {
        void Commit();
        Reservation AddReservation(Reservation newReservation);
        Reservation Get(int id);
        IEnumerable<Reservation> GetReservationsForRoom(int id);
        IEnumerable<Reservation> GetForHotel(int id);
    }

    public class SQLReservationData : IReservationManagerData
    {
        private ReservationOrganizerDbContext _context;

        public SQLReservationData(ReservationOrganizerDbContext context)
        {
            _context = context;
        }

        public Reservation Get(int id)
        {
            return _context.Reservations.FirstOrDefault(r => r.Id == id);
        }

        public Reservation AddReservation(Reservation newReservation)
        {
            _context.Reservations.Add(newReservation);
            return newReservation;
        }

        public IEnumerable<Reservation> GetReservationsForRoom(int id)
        {
            return _context.Reservations.Where(i => i.OriginId == id);
        }

        public IEnumerable<Reservation> GetForHotel(int id)
        {
            return _context.Reservations.Where(i => i.OriginHotelId == id);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
