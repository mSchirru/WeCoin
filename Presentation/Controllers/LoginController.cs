using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Presentation.ViewModels;
using reCaptcha;
using System.Configuration;
using System.Net.Http;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            ViewBag.Recaptcha = ReCaptcha.GetHtml(ConfigurationManager.AppSettings["ReCaptcha:SiteKey"]);
            ViewBag.publicKey = ConfigurationManager.AppSettings["ReCaptcha:SiteKey"];

            if (Session["userToken"] == null)
                return View();
            else
                return RedirectToAction("Home", "User");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid && ReCaptcha.Validate(ConfigurationManager.AppSettings["ReCaptcha:SecretKey"]))
            {
                string userToken = MVCUtils.GetUserToken(lvm.Email, lvm.Psw);

                if (userToken != null)
                {
                    Session["userToken"] = userToken;

                    HttpClient client = MVCUtils.GetClient("");
                    client = MVCUtils.GetClient(Session["userToken"].ToString());
                    ApplicationUserViewModel appUser = JsonConvert.DeserializeObject<ApplicationUserViewModel>(client.GetStringAsync("api/ApplicationUser/GetLoggedUser").Result);

                    Session["userId"] = appUser.Id;
                    Session["userPhoto"] = appUser.ImgUrl;
                    Session["userName"] = appUser.UserName;
                    return RedirectToAction("Home", "User");
                }

                ViewBag.Message = "Senha incorreta ou usuário não encontrado";
                ViewBag.publicKey = ConfigurationManager.AppSettings["ReCaptcha:SiteKey"];
                return View(lvm);
            }

            ViewBag.RecaptchaLastErrors = ReCaptcha.GetLastErrors(this.HttpContext);
            ViewBag.publicKey = ConfigurationManager.AppSettings["ReCaptcha:SiteKey"];

            return View();
        }
    }
}
