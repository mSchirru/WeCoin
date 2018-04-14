using Domain.Entities;
using Domain.Interfaces.Repositories;
using System.Linq;

namespace Repositories.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public int RemoveNotification(int notificationId)
        {
            Notification notification = Rc.Notifications.SingleOrDefault(n => n.NotificationId == notificationId);
            return Remove(notification);
        }
    }
}
