using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class LoginController : Controller
    {
        private const string BASE_API_ADDRESS = "http://localhost:2539";

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string psw)
        {
            //TODO: adicionar tratamento para o caso de não encontrar o usuário
            //TODO: implementar verificação nas páginas sobre um token ativo ou inativo
            string userToken = MVCUtils.GetUserToken(email, psw);
            
            if (userToken != null)
            {
                Session["userToken"] = userToken;
                return RedirectToAction("Home", "User");
            }

            return View();
        }
    }
}
