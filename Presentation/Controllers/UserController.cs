using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Web;
using Presentation.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Home()
        {
            if (Session["userToken"] == null)
                return RedirectToAction("Login", "Login");

            HttpClient client = MVCUtils.GetClient(Session["userToken"].ToString());

            ApplicationUserViewModel appUser = JsonConvert.DeserializeObject<ApplicationUserViewModel>(client.GetStringAsync("api/ApplicationUser/GetLoggedUser").Result);
            return View(appUser);
        }

        public ActionResult AcceptFriendshipRequest(string toUserId)
        {
            if (Session["userToken"] == null)
                return RedirectToAction("Login", "Login");

            HttpClient client = MVCUtils.GetClient(Session["userToken"].ToString());

            JObject requestBody = new JObject();
            requestBody["toUserId"] = toUserId;

            var j = client.PostAsJsonAsync("api/ApplicationUser/AcceptUserFriendship", requestBody).Result;

            return RedirectToAction("Home", "User");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUserPost(PostViewModel pvm)
        {
            pvm.PostTime = DateTime.Now;
            HttpClient client = MVCUtils.GetClient(Session["userToken"].ToString());

            var POSTResult = client.PostAsJsonAsync("api/ApplicationUser/CreateUserPost", pvm).Result;
            return RedirectToAction("Home", "User");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }
    }
}