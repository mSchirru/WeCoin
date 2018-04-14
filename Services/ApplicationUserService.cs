using Domain.Entities;
using System.Collections.Generic;
using Repositories.Repositories;
using System;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.IO;

namespace Services
{
    public class ApplicationUserService
    {
        private readonly ApplicationUserRepository Ar = new ApplicationUserRepository();
        private readonly NotificationRepository Nr = new NotificationRepository();

        public ApplicationUser GetUserById(string id) => Ar.GetUserById(id);

        public IEnumerable<ApplicationUser> GetUsers() => Ar.GetAll();

        public IEnumerable<ApplicationUser> GetUserFriends(string userId)
        {
            IEnumerable<Friendship> friendships = Ar.GetUserFriends(userId);
            List<ApplicationUser> friends = new List<ApplicationUser>();

            foreach (var friendship in friendships)
                friends.Add(friendship.ToApplicationUser);

            return friends;
        }

        public IEnumerable<ApplicationUser> GetUsersByName(string userName) => Ar.GetUsersByName(userName);

        public int RequestUserFriendship(JObject jObj)
        {
            string fromUserId = jObj["fromUserId"].ToString();
            string toUserId = jObj["toUserId"].ToString();

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

        public int AcceptUserFriendship(JObject jObj)
        {
            string fromUserId = jObj["fromUserId"].ToString();
            string toUserId = jObj["toUserId"].ToString();
            string notificationId = jObj["notificationId"].ToString();

            //Deleção da notificação original de pedido de amizade
            Nr.RemoveNotification(Int32.Parse(notificationId));

            Notification notification = new Notification()
            {
                Message = $"{GetUserById(fromUserId).Name} aceitou seu pedido de amizade.",
                NotificationTime = DateTime.Now,
                WasRead = false,
                NotificationIssuerId = fromUserId,
                NotifiedApplicationUserId = toUserId
            };
            
            //Criação da notificação para o solicitante, informando que o pedido de amizade foi aceito
            Nr.Add(notification);

            return Ar.AcceptUserFriendship(fromUserId, toUserId);
        }

        public int EditUser(Stream userPhoto, MultipartFormDataStreamProvider formParams)
        {
            ApplicationUser appUser = new ApplicationUser()
            {
                Id = formParams.FormData["Id"],
                Name = formParams.FormData["Name"],
                Email = formParams.FormData["Email"],
                BirthDate = DateTime.Parse(formParams.FormData["BirthDate"]),
                WalletAddress = formParams.FormData["WalletAddress"]
            };

            if (userPhoto != null)
            {
                var imageUrl = BlobService.GetUploadedFile("wecoin", formParams.FormData["Id"], userPhoto, formParams.FormData["contentType"]);
                appUser.ImgUrl = imageUrl;
            }

            return Ar.EditUser(appUser);
        }

        public int CreateUserPost(string userId, Post post) => Ar.CreateUserPost(userId, post);
    }
}
