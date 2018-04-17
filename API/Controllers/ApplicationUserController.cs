using API.DTOs;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
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

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<ApplicationUser> GetUsersByName(string userName)
        {
            return appUserService.GetUsersByName(userName);
        }

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<ApplicationUser> GetUsers()
        {
            return appUserService.GetUsers();
        }

        [AllowAnonymous]
        public IEnumerable<UserListDTO> GetUsersByRange(int offset, int quantity)
        {
            IEnumerable<ApplicationUser> applicationUsers = appUserService.GetUsersByRange(offset, quantity);
            IEnumerable<UserListDTO> users = Mapper.Map<IEnumerable<UserListDTO>>(applicationUsers);

            return users;
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
        public IHttpActionResult RequestUserFriendship(JObject jObj)
        {
            jObj["fromUserId"] = User.Identity.GetUserId();
            appUserService.RequestUserFriendship(jObj);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AcceptUserFriendship(JObject jObj)
        {
            jObj["fromUserId"] = User.Identity.GetUserId();
            appUserService.AcceptUserFriendship(jObj);
            return Ok();
        }
        
        [HttpPost]
        public async Task<IHttpActionResult> EditUser()
        {
            HttpPostedFile userPhoto = null;

            if (HttpContext.Current.Request.Files.Count > 0)
                userPhoto = HttpContext.Current.Request.Files[0];

            string appData = HttpContext.Current.Server.MapPath("~/App_Data");
            MultipartFormDataStreamProvider provider = new MultipartFormDataStreamProvider(appData);
            provider = await Request.Content.ReadAsMultipartAsync(provider);

            if (userPhoto != null)
            {
                if (appUserService.EditUser(userPhoto.InputStream, provider) > 0)
                    return Ok();
                else
                    return InternalServerError();
            }
            else
            {
                if (appUserService.EditUser(provider) > 0)
                    return Ok();
                else
                    return InternalServerError();
            }
        }
    }
}
