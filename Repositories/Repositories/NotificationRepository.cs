using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Repositories.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
    }
}
