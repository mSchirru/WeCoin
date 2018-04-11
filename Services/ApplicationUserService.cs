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
