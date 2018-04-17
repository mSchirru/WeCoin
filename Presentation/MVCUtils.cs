using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Presentation
{
    public class MVCUtils
    {
        private const string BASE_API_ADDRESS = "http://localhost:2539/";

        public static string GetUserToken(string username, string psw)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BASE_API_ADDRESS);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

            var requestBody = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", psw),
            });

            HttpResponseMessage responseMessage = client.PostAsync("/Token", requestBody).Result;

            var jsonObject = JObject.Parse(responseMessage.Content.ReadAsStringAsync().Result);
            var userToken = jsonObject.GetValue("access_token");

            return userToken != null ? userToken.ToString() : null;
        }

        public static HttpClient GetClient(string userToken)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BASE_API_ADDRESS);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", userToken);
            return client;
        }
    }
}