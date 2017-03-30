using ReservationOrganiser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationOrganiser.Services
{
    public interface INotificationManagerData
    {
        Notification Add(Notification newNotification);
        Notification Get(int id);
        IEnumerable<Notification> GetAll();

    }

    public class SQLNotoficationsManager : INotificationManagerData
    {
        private ReservationOrganizerDbContext _context;

        public SQLNotoficationsManager(ReservationOrganizerDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Notification> GetAll()
        {
            return _context.Notifications;
        }

        public Notification Get(int id)
        {
            return _context.Notifications.FirstOrDefault(i => i.Id == id);
        }

        public Notification Add(Notification newNotification)
        {
            _context.Add(newNotification);
            return newNotification;
        }
    }
}
