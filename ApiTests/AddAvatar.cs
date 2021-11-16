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
    class AddAvatar
    {
        RequestHelper requestUrl;

        [SetUp]
        public void Setup()
        {
            requestUrl = new RequestHelper("http://users.bugred.ru/tasks/rest/addavatar");
        }

        [Test]
        public void AddAvatarTest()
        {
            string email = "test@tset.st4";
            string avatar = "H:/!VisualStrudio/ApiRestLection/BugredApiTest/avatar.png";

            IRestResponse response = requestUrl.AddAvatar(email,avatar);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
