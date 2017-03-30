using ReservationOrganiser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationOrganiser.Services
{
    public interface IRoomManagerData
    {
        void Commit();
        Room AddRoom(Room newRoom);
        Room Get(int id);
        IEnumerable<Room> GetRoomsForHotel(int id);
    }

    public class SQLRoomsData : IRoomManagerData
    {
        private ReservationOrganizerDbContext _context;

        public SQLRoomsData(ReservationOrganizerDbContext context)
        {
            _context = context;
        }

        public Room Get(int id)
        {
            return _context.Rooms.FirstOrDefault(r => r.Id == id);
        }

        public Room AddRoom(Room newRoom)
        {
            _context.Rooms.Add(newRoom);
            return newRoom;
        }

        public IEnumerable<Room> GetRoomsForHotel(int id)
        {
            return _context.Rooms.Where(i => i.OriginId == id);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
