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

namespace UserBugredApi.ApiTests
{
    class CreateUserWithTasks
    {
        RequestHelper requestUrl;

        [SetUp]
        public void Setup()
        {
            requestUrl = new RequestHelper("http://users.bugred.ru/tasks/rest/createuserwithtasks");
        }

        [Test]
        public void CreateUserWithTasksValid()
        {
            CreateUserWithTasksInput createUserWithTasksInput = new CreateUserWithTasksInput()
            {
                Email = Utils.GetEmailRandom(),
                Name = Utils.GetNameRandom(),
                Tasks = new List<Task>()
                {
                    new Task { Title = "Тестовая таска1 " + Utils.GetNameRandom(), Description = "Тестовое описание таски 1 " + Utils.GetNameRandom() },
                    new Task { Title = "Тестовая таска2 " + Utils.GetNameRandom(), Description = "Тестовое описание таски 2 " + Utils.GetNameRandom() }
                },
                Companies = new List<int> {19, 20 },
                Hobby = "Стрельба из лука, Настолки",
                Adres = "адрес 1",
                Name1 = "Тестовый, ясен пень",
                Surname1 = "Иванов",
                Fathername1 = "Петров",
                Cat = "Маруся",
                Dog = "Ушастый",
                Parrot = "Васька",
                Cavy = "Кто ты?",
                Hamster = "Хомяк",
                Squirrel = "Белая горячка к нам пришла",
                Phone = "333 33 33",
                Inn = "123456789012",
                Gender = "m",
                Birthday = "01.01.1900",
                Date_start = "11.11.2000"
            };

            var postDataJson = JsonConvert.SerializeObject(createUserWithTasksInput);
            IRestResponse response = requestUrl.SendPostRequest(postDataJson);
            CreateUserWithTasksOutput companyOutput = JsonConvert.DeserializeObject<CreateUserWithTasksOutput>(response.Content);

            Assert.AreEqual(expected: null, actual: companyOutput.type);
            Assert.AreEqual(createUserWithTasksInput.Email, companyOutput.email);
            //foreach (var task in createUserWithTasksInput.Tasks)
            //{
            //    Assert.Contains(expected: task.Title, actual: companyOutput.tasks);
            //}
            
            Assert.AreEqual(createUserWithTasksInput.Name, companyOutput.name);
            Assert.AreEqual(createUserWithTasksInput.Name1, companyOutput.name1);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
