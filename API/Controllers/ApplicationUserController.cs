using Domain.Entities;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Services;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    public class ApplicationUserController : ApiController
    {
        private readonly ApplicationUserService appUserService = new ApplicationUserService();
        
        // GET api/values
        public IEnumerable<ApplicationUser> GetUsers()
        {
            return appUserService.GetAll();
        }

        [HttpPost]
        public void CreateUserPost(Post post)
        {
            string userId = User.Identity.GetUserId();
            appUserService.CreateUserPost(userId, post);
        }

        //public ApplicationUser GetUser()

        //// GET api/values/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/values/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE api/values/5
        //public void Delete(int id)
        //{
        //}
    }
}
