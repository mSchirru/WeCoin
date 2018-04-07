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

        public IEnumerable<ApplicationUser> GetAll()
        {
            return Ar.GetAll();
        }

        public void CreateUserPost(string userId, Post post)
        {
            Ar.CreateUserPost(userId, post);
        }
    }
}
