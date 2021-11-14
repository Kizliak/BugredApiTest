using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using UserBugredApi.Helpers;
using UserBugredApi.Models;

namespace UserBugredApi
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DoRegisterValidQuerry()
        {
            DoRegister doRegisterData = new DoRegister()
            {
                email = Utils.GetEmailRandom(),
                password = Utils.GetPassword(),
                name = Utils.GetNameRandom()
            };

            RequestHelper postRequest = new RequestHelper("http://users.bugred.ru/tasks/rest/doregister");

            var postDataJson = JsonConvert.SerializeObject(doRegisterData);

            //RestRequest request = new RestRequest(Method.POST);
            //request.AddHeader("content-type", "application/json");
            ////request.AddHeader("Cookie", "PHPSESSID=113a9eaaeb6b03c0334cfac7905d4714");


            //Dictionary<string, string> body = Utils.UserRegDataValid();
            //request.AddJsonBody(body);

            IRestResponse response = postRequest.SendPostResponse(postDataJson);

            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(doRegisterData.email, json["email"]?.ToString());
            Assert.AreEqual(doRegisterData.name, json["name"]?.ToString());
        }

        [Test]
        public void DoRegisterEmptyEmail()
        {
            RestClient client = new RestClient("http://users.bugred.ru/tasks/rest/doregister")
            {
                Timeout = 300000
            };
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            //request.AddHeader("Cookie", "PHPSESSID=113a9eaaeb6b03c0334cfac7905d4714");

            Dictionary<string, string> body = Utils.UserRegDataInvalidEmail();
            request.AddJsonBody(body);

            IRestResponse response = client.Execute(request);

            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.AreEqual("error", json["type"]?.ToString());
            Assert.AreEqual(" Некоректный  email ", json["message"]?.ToString());
            Assert.AreEqual(null, json["email"]?.ToString());
            Assert.AreEqual(null, json["name"]?.ToString());
        }

        [Test]
        public void DoRegisterEmptyName()
        {
            RestClient client = new RestClient("http://users.bugred.ru/tasks/rest/doregister")
            {
                Timeout = 300000
            };
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            //request.AddHeader("Cookie", "PHPSESSID=113a9eaaeb6b03c0334cfac7905d4714");

            Dictionary<string, string> body = Utils.UserRegDataInvalidEmail();
            request.AddJsonBody(body);

            IRestResponse response = client.Execute(request);

            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.AreEqual("error", json["type"]?.ToString());
            Assert.AreEqual(" Некоректный  email ", json["message"]?.ToString());
            Assert.AreEqual(null, json["email"]?.ToString());
            Assert.AreEqual(null, json["name"]?.ToString());

            //CompanyRequest company = new CompanyRequest()
            //{
            //    company_name = "",
            //    company_type = "",
            //    company_users = new List<string> { "14", "15" },
            //    email_owner = ""
            //};
            //request.AddJsonBody(company);
        }

        [Test]
        public void AuthorizationValidTest()
        {
            Dictionary<string, string> parametrs = new Dictionary<string, string>
            {
                { "email" , "dfdf@fdf.ru" },
                { "pass" , "dsfdfsf" },
                { "" , "" }
            };
            RequestHelper request = new RequestHelper("URL");
            var response = request.SendGetResponse(parametrs);
            JObject jsonResponse = JObject.Parse(response.Content);

            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual(parametrs["email"], jsonResponse["email"].ToString());
        }
    }
}