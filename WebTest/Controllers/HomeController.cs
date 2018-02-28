using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using BLL;
using AutoMapper;
using WebTest.ViewModels;

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
            List<FriendViewModelClone> friendViewModelClones = Hl.GetFriends();
            return View(Mapper.Map<List<FriendViewModel>>(friendViewModelClones));
        }

        public ActionResult IndexBirth()
        {
            List<FriendViewModelClone> friendViewModelClones = Hl.GetFriends();
            return View(Mapper.Map<List<FriendViewModel>>(friendViewModelClones));
        }

        public ActionResult SetBestFriend(int friendId)
        {
            Hl.SetBestFriend(friendId);
            return Json(new {status="OK"}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveBestFriend(int friendId)
        {
            Hl.RemoveBestFriend(friendId);
            return Json(new { status = "OK" }, JsonRequestBehavior.AllowGet);
        }
    }
}