using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Presentation.ViewModels;
using System;
using System.Globalization;
using System.IO;
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

        public ActionResult Edit(string userId)
        {
            if (Session["userToken"] == null || !(userId.Equals(Session["userId"].ToString())))
                return RedirectToAction("Login", "Login");

            HttpClient client = MVCUtils.GetClient(Session["userToken"].ToString());
            ApplicationUserViewModel appUser = JsonConvert.DeserializeObject<ApplicationUserViewModel>(client.GetStringAsync($"api/ApplicationUser/GetUserById?userId={userId}").Result);
            return View(appUser);
        }

        [HttpPost]
        public ActionResult Edit(ApplicationUserViewModel avm, HttpPostedFileBase profilePhoto)
        {
            HttpClient client = new HttpClient();
            var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["userToken"].ToString());

            MemoryStream ms = new MemoryStream();

            if (profilePhoto != null)
            {
                profilePhoto.InputStream.CopyTo(ms);
                ms.Position = 0;
                content.Add(new StreamContent(ms), "userPhoto", profilePhoto.FileName);
                content.Add(new StringContent(profilePhoto.ContentType), "contentType");
            }
            
            content.Add(new StringContent(avm.Id), "Id");
            content.Add(new StringContent(avm.Name), "Name");
            content.Add(new StringContent(avm.Email), "Email");
            content.Add(new StringContent(avm.BirthDate.ToString()), "BirthDate");
            content.Add(new StringContent(avm.WalletAddress), "WalletAddress");

            //TODO: tratar requisição para saber o sucesso ou erro da edição
            var message = client.PostAsync("http://localhost:2539/api/ApplicationUser/EditUser", content).Result;

            return RedirectToAction("Home", "User");
        }
    }
}
