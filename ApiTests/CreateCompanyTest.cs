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
    class CreateCompanyTest
    {
        RequestHelper requestUrl;

        [SetUp]
        public void Setup()
        {
            requestUrl = new RequestHelper("http://users.bugred.ru/tasks/rest/createcompany");
        }

        [Test]
        public void CreateCompanyValid()
        {
            // register new company owner
            DoRegister registerOwnerData = new DoRegister()
            {
                email = Utils.GetEmailRandom(),
                password = Utils.GetPassword(),
                name = Utils.GetNameRandom()
            };
            Thread.Sleep(500);
            Utils.RegisterUserByEmail(registerOwnerData);

            // register new user1 for company
            DoRegister registerUser1 = new DoRegister()
            {
                email = Utils.GetEmailRandom(),
                password = Utils.GetPassword(),
                name = Utils.GetNameRandom()
            };
            Thread.Sleep(500);
            Utils.RegisterUserByEmail(registerUser1);

            // register new user2 for company
            DoRegister registerUser2 = new DoRegister()
            {
                email = Utils.GetEmailRandom(),
                password = Utils.GetPassword(),
                name = Utils.GetNameRandom()
            };
            Thread.Sleep(500);
            Utils.RegisterUserByEmail(registerUser2);

            CreateCompanyInput companyInput = new CreateCompanyInput()
            {
                CompanyName = Utils.GetNameRandom(),
                CompanyType = "ООО",
                CompanyUsers = new List<string>() { registerUser1.email, registerUser2.email },
                EmailOwner = registerOwnerData.email
            };

            var postDataJson = JsonConvert.SerializeObject(companyInput);
            IRestResponse response = requestUrl.SendPostRequest(postDataJson);
            CreateCompanyOutput companyOutput = JsonConvert.DeserializeObject<CreateCompanyOutput>(response.Content);

            Assert.AreEqual("success", companyOutput.StatusType);
            Assert.AreEqual(companyInput.CompanyType, companyOutput.companyData.Type);
            Assert.AreEqual(companyInput.CompanyName, companyOutput.companyData.Name);
            Assert.AreEqual(companyInput.CompanyUsers, companyOutput.companyData.Users);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestCase ("notvalidemail@fortest.com")]
        public void CreateCompanyInvalidOwner(string ownerEmail)
        {
            // register new user1 for company
            DoRegister registerUser1 = new DoRegister()
            {
                email = Utils.GetEmailRandom(),
                password = Utils.GetPassword(),
                name = Utils.GetNameRandom()
            };
            Thread.Sleep(500);
            Utils.RegisterUserByEmail(registerUser1);

            CreateCompanyInput companyInput = new CreateCompanyInput()
            {
                CompanyName = Utils.GetNameRandom(),
                CompanyType = "ООО",
                CompanyUsers = new List<string>() { registerUser1.email },
                EmailOwner = ownerEmail
            };

            var postDataJson = JsonConvert.SerializeObject(companyInput);
            IRestResponse response = requestUrl.SendPostRequest(postDataJson);
            CreateCompanyOutput companyOutput = JsonConvert.DeserializeObject<CreateCompanyOutput>(response.Content);

            Assert.AreEqual("error", companyOutput.StatusType);
            Assert.AreEqual($"Пользователь не найден c email_owner {ownerEmail}", companyOutput.Message);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
