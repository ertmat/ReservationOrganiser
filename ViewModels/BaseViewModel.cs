using ReservationOrganiser.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationOrganiser.ViewModels
{
    public class BaseViewModel
    {
        public Hotel SelectedHotel { get; set; }

        public IEnumerable<Room> Rooms { get; set; }
    }
}
