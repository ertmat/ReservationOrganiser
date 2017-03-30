using Microsoft.AspNetCore.Http;
using System.Linq;
using ReservationOrganiser.Entities;
using System.Security.Claims;

namespace ReservationOrganiser.Services
{
    public interface IUserManagerData
    {
        User Get(string id);
        string GetLoggedUserId();
        void Commit();
    }

    public class SQLUserData : IUserManagerData
    {
        private ReservationOrganizerDbContext _context;
        private IHttpContextAccessor _httpContextAccessor;

        public SQLUserData(ReservationOrganizerDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public User Get(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public string GetLoggedUserId()
        {
            var id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            return id;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
