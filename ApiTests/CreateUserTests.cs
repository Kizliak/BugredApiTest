using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using UserBugredApi.Helpers;
using UserBugredApi.Models;

namespace UserBugredApi
{
    class CreateUserTests
    {
        RequestHelper requestUrl;

        [SetUp]
        public void Setup()
        {
            requestUrl = new RequestHelper("http://users.bugred.ru/tasks/rest/doregister");
        }

        [Test]
        public void DoRegisterValidCompany()
        {
            CreateCompany createCompany = new CreateCompany()
            {
                company_name = Utils.GetNameRandom(),
                company_type = "ООО",
                company_users = new List<string>() { "1230391115213917@gomotrio.com", "1230381115218538@gomotrio.com" }, //заменить на рандомно зарегенный перед этим
                email_owner = "dfdsfdf@dfdfdfffhsddfsdffsdfjdfhj.com" //заменить на рандомно зарегенный перед этим
            };
            Thread.Sleep(500);

            var postDataJson = JsonConvert.SerializeObject(doRegisterData);
            IRestResponse response = requestUrl.SendPostRequest(postDataJson);
            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual(doRegisterData.email, json["email"]?.ToString());
            Assert.AreEqual(doRegisterData.name, json["name"]?.ToString());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
