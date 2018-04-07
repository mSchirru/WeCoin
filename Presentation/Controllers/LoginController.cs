using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class LoginController : Controller
    {
        private const string BASE_API_ADDRESS = "http://localhost:2539";

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        private ActionResult Login(FormCollection formCollection)
        {
            Session["userToken"] = MVCUtils.SetSessionToken(formCollection["loginEmail"], formCollection["loginPsw"]);

            return RedirectToAction("Index", "HomeController");
        }
    }
}
