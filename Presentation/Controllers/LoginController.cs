using Newtonsoft.Json;
using Presentation.ViewModels;
using System.Net.Http;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            if (Session["userToken"] == null)
                return View();
            else
                return RedirectToAction("Home", "User");
        }

        [HttpPost]
        public ActionResult Login(string email, string psw)
        {
            string userToken = MVCUtils.GetUserToken(email, psw);
            
            if (userToken != null)
            {
                Session["userToken"] = userToken;

                HttpClient client = MVCUtils.GetClient(Session["userToken"].ToString());
                ApplicationUserViewModel appUser = JsonConvert.DeserializeObject<ApplicationUserViewModel>(client.GetStringAsync("api/ApplicationUser/GetLoggedUser").Result);

                Session["userId"] = appUser.Id;
                Session["userPhoto"] = appUser.ImgUrl;
                Session["userName"] = appUser.UserName;
                return RedirectToAction("Home", "User");
            }

            ViewBag.Message = "Senha incorreta ou usuário não encontrado";
            return View();
        }
    }
}
