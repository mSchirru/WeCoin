using Newtonsoft.Json.Linq;
using Presentation.ViewModels;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(ApplicationUserViewModel avm)
        {
            if (!ModelState.IsValid)
                return View(avm);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2539");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            JObject requestBody = JObject.FromObject(avm);
            
            client.PostAsJsonAsync("api/Account/Register", requestBody);

            //TODO: registrar usuário e receber sinal de sucesso ou erro no cadastro
            return RedirectToAction("Login", "Login");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
