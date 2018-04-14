using Domain.Entities;
using Newtonsoft.Json.Linq;
using Services;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class NotificationController : ApiController
    {
        private readonly NotificationService Ns = new NotificationService();

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<Notification> GetNotifications() => Ns.GetNotifications();

        [Authorize]
        [HttpPost]
        public int DeleteNotification(JObject requestBody)
        {
            string s = requestBody["notificationId"].ToString();
            return Ns.DeleteNotification(Int32.Parse(s));
        }
    }
}