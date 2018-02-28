using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using BLL;

namespace WebTest.Controllers
{
    public class HomeController : Controller
    {
        private HomeLogic Hl = new HomeLogic();

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            if (Session["BestFriendIds"] == null)
                Session["BestFriendIds"] = new List<int>();
        }

        public ActionResult Index()
        {
            return View(Hl.GetFriends(Session["BestFriendIds"]));
        }

        public ActionResult IndexBirth()
        {
            return View(Hl.GetFriends(Session["BestFriendIds"]));
        }

        public ActionResult SetBestFriend(int friendId)
        {
            Hl.SetBestFriend(Session["BestFriendIds"], friendId);
            return Json(new {status="OK"}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveBestFriend(int friendId)
        {
            Hl.RemoveBestFriend(Session["BestFriendIds"], friendId);
            return Json(new { status = "OK" }, JsonRequestBehavior.AllowGet);
        }
    }
}