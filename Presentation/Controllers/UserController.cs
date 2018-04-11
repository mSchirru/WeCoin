using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Web;
using AutoMapper;
using Presentation.ViewModels;
using Newtonsoft.Json;

namespace Presentation.Controllers
{
    public class UserController : Controller
    {
        private const string BASE_API_ADDRESS = "http://localhost:2539";

        public ActionResult Home()
        {
            //TODO: a partir da lista de usuários, carregar posts relativos ao usuário logado

            if (Session["userToken"] == null)
                return RedirectToAction("Login", "Login");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BASE_API_ADDRESS);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["userToken"].ToString());
            
            //Chamada para pegar todos os amigos de um usuário
            //var z = client.GetStringAsync("api/ApplicationUser/GetUserFriends").Result;

            ApplicationUserViewModel appUser = JsonConvert.DeserializeObject<ApplicationUserViewModel>(client.GetStringAsync("api/ApplicationUser/GetLoggedUser").Result);
            return View(appUser);
        }

        public ActionResult Edit()
        {
            if (Session["userToken"] == null)
                return RedirectToAction("Login", "Login");

            return View();
        }

        [HttpPost]
        public ActionResult Edit(ApplicationUserViewModel profile, HttpPostedFileBase profilePhoto)
        {
            //if (ModelState.IsValid)
            //{
            //    //---- Upload da Foto ----
            //    //TODO: corrigir upload no serviço de blob
            //    profile.ImgUrl = Services.BlobService.GetInstance()
            //        .UploadFile("simplesocialnetwork", profile.Id, profilePhoto.InputStream, profilePhoto.ContentType);
            //    //------------------------
            //    //HttpClient 
            //    return RedirectToAction("Index");
            //}

            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUserPost(PostViewModel pvm)
        {
            pvm.PostTime = DateTime.Now;
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Home", "User");
            }
            catch
            {
                return View();
            }
        }
    }
}