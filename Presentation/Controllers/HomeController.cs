using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Domain.Entities;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private async Task<string> GetRequest(string token, string apiBaseUri, string requestPath)
        {
            using (var client = new HttpClient())
            {
                //setup client
                client.BaseAddress = new Uri(apiBaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

                //make request
                HttpResponseMessage response = await client.GetAsync(requestPath);
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }

        public ActionResult Index()
        {
            //HttpClient client = new HttpClient();

            //const string userName = "noisefoda@foda.com.br";
            //const string password = "$oTemFoda";
            //const string apiBaseUri = "http://localhost:2539/";
            //const string apiGetValues = "api/values";

            ////setup client
            //client.BaseAddress = new Uri(apiBaseUri);
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //JObject requestBody = new JObject();
            //requestBody.Add("Email", "alex@hotmail.com");
            //requestBody.Add("FirstName", "alex moro");
            //requestBody.Add("LastName", "Jesus");
            //requestBody.Add("Password", "1Pud!m");
            //requestBody.Add("ConfirmPassword", "1Pud!m");

            //send request
            //HttpResponseMessage responseMessage = client.PostAsJsonAsync("api/Account/Register", requestBody).Result;

            //get access token from response body
            //var jsonObject = JObject.Parse(responseMessage.Content.ReadAsStringAsync().Result);
            //jsonObject.GetValue("access_token").ToString();




            //PEGANDO TOKEN
            HttpClient client = new HttpClient();

            const string apiBaseUri = "http://localhost:2539/";
            
            client.BaseAddress = new Uri(apiBaseUri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            var requestBody = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", "diegovictorbr@hotmail.com"),
                    new KeyValuePair<string, string>("password", "1Pud!m"),
            });

            HttpResponseMessage responseMessage = client.PostAsync("/Token", requestBody).Result;
            
            var jsonObject = JObject.Parse(responseMessage.Content.ReadAsStringAsync().Result);
            Session["userToken"] = jsonObject.GetValue("access_token").ToString();
            //PEGANDO TOKEN



            //USANDO TOKEN PARA CONSUMIR UM ENDPOINT

            //setup client
            client.DefaultRequestHeaders.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Session["userToken"].ToString());


            JArray users = JArray.Parse(client.GetStringAsync("api/Values").Result);

            IEnumerable<ApplicationUser> appUsers = users.ToObject<IEnumerable<ApplicationUser>>();

            //List<UserViewModel> users = ToObject<List<UserViewModel>>();
            //USANDO TOKEN PARA CONSUMIR UM ENDPOINT

            // TODO: receber lista de usuários do endpoint e converter usando AutoMapper

            //var token = GetAPIToken(userName, password, apiBaseUri).Result;
            //Console.WriteLine("Token: {0}", token);

            //var response = GetRequest(token, apiBaseUri, apiGetValues).Result;
            //Console.WriteLine("response: {0}", response);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}