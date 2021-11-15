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
        public void DoRegisterValidCompany()
        {
            CreateCompanyInput companyInput = new CreateCompanyInput()
            {
                CompanyName = Utils.GetNameRandom(),
                CompanyType = "ООО",
                CompanyUsers = new List<string>() { "0155461115214159@gomotrio.com", "0155541115213116@gomotrio.com" }, //заменить на рандомно зарегенный перед этим
                EmailOwner = "millfffffi@mail.ru" //заменить на рандомно зарегенный перед этим
            };

            Thread.Sleep(500);

            var postDataJson = JsonConvert.SerializeObject(companyInput);
            IRestResponse response = requestUrl.SendPostRequest(postDataJson);
            //JObject json = JObject.Parse(response.Content);

            CreateCompanyOutput companyOutput = JsonConvert.DeserializeObject<CreateCompanyOutput>(response.Content);

            Assert.AreEqual("success", companyOutput.Type);
            Assert.AreEqual(companyInput.CompanyType, companyOutput.companyData.Type);
            Assert.AreEqual(companyInput.CompanyName, companyOutput.companyData.Name);
            Assert.AreEqual(companyInput.CompanyUsers, companyOutput.companyData.Users);
            //Assert.AreEqual(createCompany.company_users.ToString(), json["company"]["users"]?.ToString());
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
