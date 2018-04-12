using Domain.Entities;
using System.Collections.Generic;
using Repositories.Repositories;
using System;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Services
{
    public class ApplicationUserService
    {
        private readonly ApplicationUserRepository Ar = new ApplicationUserRepository();
        private readonly NotificationRepository Nr = new NotificationRepository();

        public ApplicationUser GetUserById(string id)
        {
            return Ar.GetUserById(id);
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return Ar.GetAll();
        }

        public IEnumerable<ApplicationUser> GetUserFriends(string userId)
        {
            //TODO: converter friendships numa lista de applicationusers
            IEnumerable<Friendship> friendships = Ar.GetUserFriends(userId);
            List<ApplicationUser> friends = new List<ApplicationUser>();

            foreach (var friendship in friendships)
                friends.Add(friendship.ToApplicationUser);

            return friends;
        }

        public int RequestUserFriendship(string fromUserId, string toUserId)
        {
            Notification notification = new Notification()
            {
                Message = $"{GetUserById(fromUserId).Name} gostaria de ser seu amigo.",
                NotificationTime = DateTime.Now,
                WasRead = false,
                NotificationIssuerId = fromUserId,
                NotifiedApplicationUserId = toUserId
            };

            Nr.Add(notification);

            return Ar.RequestUserFriendship(fromUserId, toUserId);
        }

        //Ids agora invertidos: quem recebeu o pedido em from, quem requisitou em to
        public int AcceptUserFriendship(string fromUserId, string toUserId)
        {
            Notification notification = new Notification()
            {
                Message = $"{GetUserById(fromUserId).Name} aceitou seu pedido de amizade.",
                NotificationTime = DateTime.Now,
                WasRead = false,
                NotificationIssuerId = fromUserId,
                NotifiedApplicationUserId = toUserId
            };

            Nr.Add(notification);

            return Ar.AcceptUserFriendship(fromUserId, toUserId);
        }

        public int EditUser(ApplicationUser appUser)
        {
            return Ar.EditUser(appUser);
        }

        public int CreateUserPost(string userId, Post post)
        {
            return Ar.CreateUserPost(userId, post);
        }
    }
}
