using Newtonsoft.Json.Linq;
using Services;
using System;
using System.Web.Http;

namespace API.Controllers
{
    public class PostController : ApiController
    {
        private readonly PostService Ns = new PostService();

        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //public string Get(int id)
        //{
        //    return "value";
        //}
        //public void Post([FromBody]string value)
        //{
        //}

        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //HTTP DELETE method?
        [Authorize]
        [HttpPost]
        public void Delete(JObject requestBody)
        {
            string s = requestBody["postId"].ToString();
            Ns.DeletePost(Int32.Parse(s));
        }
    }
}
