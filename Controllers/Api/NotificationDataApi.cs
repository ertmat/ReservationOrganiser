using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReservationOrganiser.Services;
using ReservationOrganiser.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservationOrganiser.Controllers.Api
{
    [Route("api/[controller]")]
    public class NotificationDataApi : Controller
    {
        private INotificationManagerData _notificationManager;
        private IUserManagerData _userManager;

        public NotificationDataApi(INotificationManagerData notificationManager, IUserManagerData userManager)
        {
            _notificationManager = notificationManager;
            _userManager = userManager;
        }

        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    var loggedUser = _userManager.GetLoggedUserId();
        //    var notifications = _notificationManager.GetForUser(loggedUser);

        //    var model = new NotificationData();

        //    foreach(var noti in notifications)
        //    {
        //        model.cdate = noti.CDate;
        //        model.title = noti.Title;
        //        model.description = noti.Description;
        //        model.readed = noti.Readed;
        //    }

        //    return View(model);
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
