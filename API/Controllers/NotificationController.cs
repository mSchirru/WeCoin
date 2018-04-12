using Domain.Entities;
using Services;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    public class NotificationController : ApiController
    {
        private readonly NotificationService Ns = new NotificationService();

        [HttpGet]
        public IEnumerable<Notification> GetNotifications()
        {
            return Ns.GetNotifications();
        }
    }
}
