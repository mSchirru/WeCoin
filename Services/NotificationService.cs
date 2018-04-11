using Domain.Entities;
using Repositories.Repositories;
using System.Collections.Generic;

namespace Services
{
    public class NotificationService
    {
        private readonly NotificationRepository Ar = new NotificationRepository();

        public IEnumerable<Notification> GetAll()
        {
            return Ar.GetAll();
        }

        public void CreateNotification(string userId, Post post)
        {
            //Ar.CreateUserPost(userId, post);
            //TODO: criar notificações para os usuários
        }   
    }
}
