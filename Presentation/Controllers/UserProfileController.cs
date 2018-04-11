using Newtonsoft.Json;
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
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["userToken"].ToString());
            
            //Criação de requisição GET com query strings
            UriBuilder endpoint = new UriBuilder("http://localhost:2539/api/ApplicationUser/GetUserById");
            endpoint.Query = $"userId={userId}";

            ApplicationUserViewModel appUser = JsonConvert.DeserializeObject<ApplicationUserViewModel>(client.GetStringAsync(endpoint.Uri).Result);
            return View(appUser);
        }

        
        public ActionResult MakeFriendshipRequest()
        {
            return View();
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

        // GET: UserProfile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserProfile/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
