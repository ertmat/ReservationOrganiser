using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReservationManagerData.Services;
using ReservationOrganiser.Entities;
using ReservationOrganiser.Services;
using ReservationOrganiser.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReservationOrganiser.Controllers
{
    public class HomeController : Controller
    {
        private IHotelManagerData _hotelManager;
        private IDaysManager _daysManager;
        private IUserManagerData _userManagerData;
        private IRoomManagerData _roomManagerData;
        private IReservationManagerData _reservationManagerData;

        public HomeController(IHotelManagerData hotelManager, 
                              IDaysManager daysManager, 
                              IUserManagerData userManagerData, 
                              IRoomManagerData roomManagerData, 
                              IReservationManagerData reservationManagerData)
        {
            _hotelManager = hotelManager;
            _daysManager = daysManager;
            _userManagerData = userManagerData;
            _roomManagerData = roomManagerData;
            _reservationManagerData = reservationManagerData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            var model = new DashboardViewModel();
            var userId = _userManagerData.GetLoggedUserId();
            var user = _userManagerData.Get(userId);
            var selectedHotel = _hotelManager.Get(user.SelectedHotelId);
            model.Hotels = _hotelManager.GetForUser(userId);
            //Zmienić żeby nie ustawiało tutaj
            //Przy zapisywaniu pierwszego hotelu dla Usera ma się ustawić jeśli nie ma.
            //Tutaj ma tylko pobierać, a w ustawieniach usera zrobię, żeby można bylo
            //Domyślny hotel zmieniać
            model.SelectedHotel = selectedHotel;
            model.Reservations = _reservationManagerData.GetForHotel(selectedHotel.Id);
            model.Rooms = _roomManagerData.GetRoomsForHotel(selectedHotel.Id);

            return View(model);
        }

        public IActionResult Hotel(HotelViewModel model, int id)
        {
            var hotel = _hotelManager.Get(id);
            model.Name = hotel.Name;
            

            var maxDays = DateTime.DaysInMonth(2017,2);
            var bookedDays = _daysManager.GetBooked();
            List<CalendarDay> daysInMonth = new List<CalendarDay>();

            model.Rooms = _roomManagerData.GetRoomsForHotel(id);

            //var keyIndex = daysInMonth.FindIndex(i => i.Id == );

            for (int i = 0; i < maxDays; i++)
            {
                //if(day.Number == keyIndex)
                //{
                //    daysInMonth.Add(_daysManager.)
                //}
                daysInMonth.Add(new CalendarDay());
            }
            //model.CalendarDays = daysInMonth;

            return View(model);
        }

        public IActionResult Room(RoomViewModel model, int id)
        {
            var room = _roomManagerData.Get(id);
            var userId = _userManagerData.GetLoggedUserId();
            var user = _userManagerData.Get(userId);

            var selectedHotel = _hotelManager.Get(user.SelectedHotelId);
            model.Hotels = _hotelManager.GetForUser(userId);
            
            model.Name = room.Name;
            model.Capacity = room.Capacity;
            model.SelectedHotel = selectedHotel;
            model.Rooms = _roomManagerData.GetRoomsForHotel(selectedHotel.Id);
            model.Reservations = _reservationManagerData.GetReservationsForRoom(id);

            double totalEarn = 0;

            if(model.Reservations.Count() != 0)
            {
                foreach (var earn in model.Reservations)
                {
                    var totalDays = (earn.EndDate - earn.StartDate).TotalDays;
                    totalEarn += (earn.Price * totalDays);
                }
            }

            model.TotalEarn = totalEarn;

            string calendarData = "";
            foreach(var reservation in model.Reservations)
            {
                if(reservation.jsonData != null)
                {
                    calendarData += reservation.jsonData;
                }
            }
            model.jsonData = calendarData;

            return View(model);
        }

        public IActionResult Reservation(ReservationViewModel model, int id)
        {
            var userId = _userManagerData.GetLoggedUserId();
            var user = _userManagerData.Get(userId);

            var selectedHotel = _hotelManager.Get(user.SelectedHotelId);

            var reservation = _reservationManagerData.Get(id);
           
            model.Name = reservation.Name;
            model.Description = reservation.Description;

            model.OriginId = reservation.OriginId;
            model.ResRoom = _roomManagerData.Get(reservation.OriginId);

            model.Guests = reservation.Guests;
            model.StartDate = reservation.StartDate;
            model.EndDate = reservation.EndDate;
            var totaldays = (reservation.EndDate - reservation.StartDate).TotalDays;
            model.TotalDays = totaldays;

            model.Deposit = reservation.Deposit;
            model.Price = reservation.Price;
            model.TotalPrice = model.Price * model.TotalDays;
            model.ToPay = model.TotalPrice - model.Deposit;

            model.jsonData = reservation.jsonData;
            model.SelectedHotel = selectedHotel;
            model.Reservations = _reservationManagerData.GetReservationsForRoom(reservation.OriginId);

            return View(model);
        }

        [HttpGet]
        public IActionResult AddHotel()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddHotel(HotelViewModel model, int id)
        {
            string userId = _userManagerData.GetLoggedUserId();
            var user = _userManagerData.Get(userId);
            var hotel = _hotelManager.Get(id);

            if (hotel.OwnerId == null)
            {
                hotel.OwnerId = userId;
                hotel.Name = model.Name;
                _hotelManager.Commit();
                return RedirectToAction("Dashboard");
            }
            else
            {
                var newhotel = new Hotel();

                newhotel.Name = model.Name;
                newhotel.Status = 1;
                newhotel.OwnerId = userId;

                _hotelManager.Add(newhotel);
                _hotelManager.Commit();

                return RedirectToAction("Dashboard");
            }


        }

        [HttpGet]
        public IActionResult AddRoom(int id)
        {
            var model = new RoomViewModel();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddRoom(RoomViewModel model, int id)
        {
            var room = new Room();

            room.Name = model.Name;
            room.Capacity = model.Capacity;
            room.OriginId = id;

            _roomManagerData.AddRoom(room);
            _roomManagerData.Commit();

            return RedirectToAction("Room", new { id = room.Id } );
        }

        [HttpGet]
        public IActionResult AddReservation(int id)
        {
            var model = new ReservationViewModel();

            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddReservation(ReservationViewModel model, int id)
        {
            var reservation = new Reservation();
            var room = _roomManagerData.Get(id);
            reservation.Name = model.Name;
            reservation.Description = model.Description;
            reservation.Guests = model.Guests;
            reservation.Price = model.Price;
            reservation.Deposit = model.Deposit;
            reservation.StartDate = model.StartDate;
            reservation.EndDate = model.EndDate;
            //Room ID
            reservation.OriginId = id;
            //Hotel ID
            reservation.OriginHotelId = room.OriginId;

            List<ReservationData> _data = new List<ReservationData>();
            _data.Add(new ReservationData()

            {
                title = reservation.Name,
                start = reservation.StartDate,
                end = reservation.EndDate,
                className = "colorTheme"
            });
            string json = JsonConvert.SerializeObject(_data.ToArray());
            char[] pren = { '[', ']' };
            string calendarData = json.Trim(pren);
            reservation.jsonData = calendarData;

            _reservationManagerData.AddReservation(reservation);
            _reservationManagerData.Commit();

            return RedirectToAction("Reservation", new { id = reservation.Id });
        }
    }
}
