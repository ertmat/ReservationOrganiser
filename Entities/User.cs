using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ReservationOrganiser.Entities
{
    public class User : IdentityUser
    {
        public int SelectedHotelId { get; set; }
        public int UserAccess { get; set; }
    }
}