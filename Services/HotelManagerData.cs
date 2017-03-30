using ReservationOrganiser.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ReservationOrganiser.Services
{
    public interface IHotelManagerData
    {
        void Commit();
        IEnumerable<Hotel> GetAll();
        IEnumerable<Hotel> GetForUser(string id);
        Hotel Get(int id);
        Hotel FirstForUser(string id);
        Hotel GetSelectedHotel(int id);
        Hotel Add(Hotel newHotel);
    }

    public class SQLHotelData : IHotelManagerData
    {
        private ReservationOrganizerDbContext _context;
        private IUserManagerData _userManagerData;

        public SQLHotelData(ReservationOrganizerDbContext context, IUserManagerData userManagerData)
        {
            _context = context;
            _userManagerData = userManagerData;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _context.Hotels;
        }

        public Hotel Get(int id)
        {
            return _context.Hotels.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Hotel> GetForUser(string id)
        {
            return _context.Hotels.Where(o => o.OwnerId == id);
        }

        public Hotel FirstForUser(string id)
        {
            return _context.Hotels.First(i => i.OwnerId == id);
        }

        public Hotel GetSelectedHotel(int id)
        {
            return _context.Hotels.Single(i => i.Id == id);
        }

        public Hotel Add(Hotel newHotel)
        {
            _context.Hotels.Add(newHotel);
            return newHotel;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
