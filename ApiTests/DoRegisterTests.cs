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
    public class DoRegisterTests
    {
        RequestHelper requestUrl;

        [SetUp]
        public void Setup()
        {
            requestUrl = new RequestHelper("http://users.bugred.ru/tasks/rest/doregister");
        }

        [Test]
        public void DoRegisterValidDataPostRequest()
        {
            DoRegister doRegisterData = new DoRegister()
            {
                email = Utils.GetEmailRandom(),
                password = Utils.GetPassword(),
                name = Utils.GetNameRandom()
            };
            Thread.Sleep(500);

            var postDataJson = JsonConvert.SerializeObject(doRegisterData);
            IRestResponse response = requestUrl.SendPostRequest(postDataJson);
            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual(doRegisterData.email, json["email"]?.ToString());
            Assert.AreEqual(doRegisterData.name, json["name"]?.ToString());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public void DoRegisterNullEmail()
        {
            DoRegister doRegisterData = new DoRegister()
            {
                email = "",
                password = Utils.GetPassword(),
                name = Utils.GetNameRandom()
            };
            Thread.Sleep(500);

            var postDataJson = JsonConvert.SerializeObject(doRegisterData);
            IRestResponse response = requestUrl.SendPostRequest(postDataJson);
            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual("error", json["type"]?.ToString());
            Assert.AreEqual("Некоректный  email", json["message"]?.ToString());
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public void DoRegisterNullName()
        {
            DoRegister doRegisterData = new DoRegister()
            {
                email = Utils.GetEmailRandom(),
                password = Utils.GetPassword(),
                name = ""
            };
            Thread.Sleep(500);

            var postDataJson = JsonConvert.SerializeObject(doRegisterData);
            IRestResponse response = requestUrl.SendPostRequest(postDataJson);
            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual("error", json["type"]?.ToString());
            Assert.AreEqual("поле фио является обязательным", json["message"]?.ToString());
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public void DoRegisterNullPassword()
        {
            DoRegister doRegisterData = new DoRegister()
            {
                email = Utils.GetEmailRandom(),
                password ="",
                name = Utils.GetNameRandom()
            };
            Thread.Sleep(500);

            var postDataJson = JsonConvert.SerializeObject(doRegisterData);
            IRestResponse response = requestUrl.SendPostRequest(postDataJson);
            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual("error", json["type"]?.ToString());
            Assert.AreEqual("Некоректный  пароль", json["message"]?.ToString());
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public void DoRegisterAlreadyUsedEmail()
        {
            DoRegister doRegisterData = new DoRegister()
            {
                email = Utils.GetEmailRandom(),
                password = Utils.GetPassword(),
                name = Utils.GetNameRandom()
            };
            Thread.Sleep(500);

            var postDataJson = JsonConvert.SerializeObject(doRegisterData);
            requestUrl.SendPostRequest(postDataJson);

            DoRegister doRegisterUsedEmailData = new DoRegister()
            {
                email = doRegisterData.email,
                password = Utils.GetPassword(),
                name = Utils.GetNameRandom()
            };

            var postDataUsedEmailJson = JsonConvert.SerializeObject(doRegisterUsedEmailData);
            IRestResponse response = requestUrl.SendPostRequest(postDataUsedEmailJson);
            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual("error", json["type"]?.ToString());
            Assert.AreEqual($"email {doRegisterUsedEmailData.email} уже есть в базе", json["message"]?.ToString());
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public void DoRegisterAlreadyUsedName()
        {
            DoRegister doRegisterData = new DoRegister()
            {
                email = Utils.GetEmailRandom(),
                password = Utils.GetPassword(),
                name = Utils.GetNameRandom()
            };
            Thread.Sleep(500);

            var postDataJson = JsonConvert.SerializeObject(doRegisterData);
            requestUrl.SendPostRequest(postDataJson);

            DoRegister doRegisterUsedEmailData = new DoRegister()
            {
                email = Utils.GetEmailRandom(),
                password = Utils.GetPassword(),
                name = doRegisterData.name
            };

            var postDataUsedEmailJson = JsonConvert.SerializeObject(doRegisterUsedEmailData);
            IRestResponse response = requestUrl.SendPostRequest(postDataUsedEmailJson);
            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual("error", json["type"]?.ToString());
            Assert.AreEqual($"Текущее ФИО {doRegisterUsedEmailData.name} уже есть в базе", json["message"]?.ToString());
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public void DoRegisterValidDataGetRequest()
        {
            Dictionary<string, string> DoRegisterData = new Dictionary<string, string>()
            {
                { "email", Utils.GetEmailRandom()},
                { "password", Utils.GetPassword()},
                { "name", Utils.GetNameRandom()},
            };

            IRestResponse response = requestUrl.SendGetRequest(DoRegisterData);
            JObject json = JObject.Parse(response.Content);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}