using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class LoginController : Controller
    {
        private const string BASE_API_ADDRESS = "http://localhost:2539";

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
            //TODO: implementar verificação nas páginas sobre um token ativo ou inativo
            string userToken = MVCUtils.GetUserToken(email, psw);
            
            if (userToken != null)
            {
                Session["userToken"] = userToken;
                return RedirectToAction("Home", "User");
            }

            ViewBag.Message = "Senha incorreta ou usuário não encontrado";
            return View();
        }
    }
}
