using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Presentation.ViewModels;
using Newtonsoft.Json;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private const string BASE_API_ADDRESS = "http://localhost:2539";

        public ActionResult Index()
        {
            //if (Session["userToken"] == null)
            //    return RedirectToAction("Login");

            //return View();

            Session["userToken"] = MVCUtils.SetSessionToken("jacinto@gmail.com", "1Pud!m");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BASE_API_ADDRESS);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["userToken"].ToString());

            IEnumerable<ApplicationUserViewModel> appUsers = JsonConvert.DeserializeObject<IEnumerable<ApplicationUserViewModel>>(client.GetStringAsync("api/ApplicationUser").Result);      
            return View();
        }
    }
}