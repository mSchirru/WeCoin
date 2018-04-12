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
        private void RegisterUser(string email, string name, string psw, string confirmationPsw, DateTime date)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:2539");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         
            JObject requestBody = new JObject();
            requestBody.Add("Email", email);
            requestBody.Add("Name", name);
            requestBody.Add("Password", psw);
            requestBody.Add("ConfirmPassword", confirmationPsw);
            requestBody.Add("Date", date);

            client.PostAsJsonAsync("api/Account/Register", requestBody);
            // TODO: implementar indicação do resultado do POST de cadastro
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(ApplicationUserViewModel avm)
        {
            //TODO: registrar usuário e receber sinal de sucesso ou erro no cadastro
            RegisterUser(avm.Email, avm.Name, avm.Password, avm.ConfirmPassword, avm.BirthDate);            

            if (ModelState.IsValid)
                return RedirectToAction("Login", "Login");

            return View(avm);
        }
    }
}
