using Domain.Entities;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class NotificationService
    {
        private readonly NotificationRepository Nr = new NotificationRepository();

        public IEnumerable<Notification> GetNotifications() => Nr.GetAll();

        public int DeleteNotification(int notificationId) => Nr.RemoveNotification(notificationId);
    }
}
