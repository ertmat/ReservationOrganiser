using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationOrganiser.Entities
{
    public class NotificationData
    {
        public string title { get; set; }
        public string description { get; set; }
        public bool readed { get; set; }

        public DateTime cdate { get; set; }
    }
}
