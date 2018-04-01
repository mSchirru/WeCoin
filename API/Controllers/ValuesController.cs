using Domain.Entities;
using Services;
using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private readonly ApplicationUserService appUserService = new ApplicationUserService();
        
        // GET api/values
        public IEnumerable<ApplicationUser> GetUsers()
        {
            return appUserService.GetAll();
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
