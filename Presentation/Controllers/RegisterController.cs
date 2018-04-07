using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class RegisterController : Controller
    {
        private const string BASE_API_ADDRESS = "http://localhost:2539";

        public ActionResult Index()
        {
            return View();
        }

        public void RegisterUser(string email, string name, string psw, string confirmationPsw)
        {
            HttpClient client = new HttpClient();
            const string apiEndpoint = "api/Account/Register";

            client.BaseAddress = new Uri(BASE_API_ADDRESS);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            JObject requestBody = new JObject();
            requestBody.Add("Email", email);
            requestBody.Add("Name", name);
            requestBody.Add("Password", psw);
            requestBody.Add("ConfirmPassword", confirmationPsw);

            client.PostAsJsonAsync(apiEndpoint, requestBody);
            // TODO: implementar indicação do resultado do POST de cadastro
        }
    }
}
