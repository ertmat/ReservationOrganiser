using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationOrganiser.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool Readed { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public DateTime CDate { get; set; }
    }
}
