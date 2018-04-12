using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class UserProfileController : Controller
    {
        public ActionResult Details(string userId)
        {
            if (Session["userToken"] == null)
                return RedirectToAction("Login", "Login");

            HttpClient client = MVCUtils.GetClient(Session["userToken"].ToString());
            
            //Criação de requisição GET com query strings
            UriBuilder endpoint = new UriBuilder("http://localhost:2539/api/ApplicationUser/GetUserById");
            endpoint.Query = $"userId={userId}";

            ApplicationUserViewModel appUser = JsonConvert.DeserializeObject<ApplicationUserViewModel>(client.GetStringAsync(endpoint.Uri).Result);
            return View(appUser);
        }

        
        public ActionResult MakeFriendshipRequest(string toUserId)
        {
            if (Session["userToken"] == null)
                return RedirectToAction("Login", "Login");

            if (toUserId.Equals(Session["userId"]))
                return RedirectToAction("Details", "UserProfile", routeValues: new { userId = toUserId });

            HttpClient client = MVCUtils.GetClient(Session["userToken"].ToString());

            JObject requestBody = new JObject();
            requestBody["toUserId"] = toUserId;

            var j = client.PostAsJsonAsync("api/ApplicationUser/RequestUserFriendship", requestBody).Result;

            return RedirectToAction("Details", "UserProfile", routeValues: new { userId = toUserId });
        }

        // GET: UserProfile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserProfile/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
