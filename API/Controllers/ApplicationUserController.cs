using Domain.Entities;
using Microsoft.AspNet.Identity;
using Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    public class ApplicationUserController : ApiController
    {
        private readonly ApplicationUserService appUserService = new ApplicationUserService();
        
        [HttpGet]
        public ApplicationUser GetLoggedUser()
        {
            return appUserService.GetUserById(User.Identity.GetUserId());
        }

        [HttpGet]
        public ApplicationUser GetUserById(string userId)
        {
            return appUserService.GetUserById(userId);
        }

        [HttpGet]
        public IEnumerable<ApplicationUser> GetUsers()
        {
            return appUserService.GetUsers();
        }

        public IEnumerable<ApplicationUser> GetUserFriends()
        {
            string userId = User.Identity.GetUserId();
            return appUserService.GetUserFriends(userId);
        }

        [HttpPost]
        public IHttpActionResult CreateUserPost(Post post)
        {
            string userId = User.Identity.GetUserId();
            
            //True quando algum objeto for alterado na chamada de SaveChanges
            if (appUserService.CreateUserPost(userId, post) > 0)
                return Ok();
            else
                return InternalServerError();
        }
        
        [HttpPost]
        public IHttpActionResult EditUser(ApplicationUser appUser)
        {
            //True quando algum objeto for alterado na chamada de SaveChanges
            if (appUserService.EditUser(appUser) > 0)
                return Ok();
            else
                return InternalServerError();
        }
    }
}
