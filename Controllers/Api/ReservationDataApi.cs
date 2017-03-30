using Microsoft.AspNetCore.Mvc;
using ReservationManagerData.Services;
using ReservationOrganiser.Entities;

namespace ReservationOrganiser.Controllers.Api
{
    [Route("api")]
    public class ReservationDataApi : Controller
    {
        private IReservationManagerData _reservationManager;

        public ReservationDataApi(IReservationManagerData reservationManager)
        {
            _reservationManager = reservationManager;
        }

        [HttpGet("reservation/{id}")]
        public IActionResult GetReservationJson(int id)
        {
            var reservation = _reservationManager.Get(id);
            var model = new ReservationData();
            model.title = reservation.Name;
            model.start = reservation.StartDate;
            model.end = reservation.EndDate;
            model.className = "colorTheme";

            return Ok(model);
        }
    }
}
