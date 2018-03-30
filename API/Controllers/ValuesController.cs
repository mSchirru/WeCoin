using System.Collections.Generic;
using System.Web.Http;

namespace API.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private List<string> test_list = new List<string>
        {
            "Mikael", "Alexandre", "Lapa", "Diego", "Joao"
        };

        // GET api/values
        [HttpPost]
        public IEnumerable<string> Get()
        {
            return test_list;
        }

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
