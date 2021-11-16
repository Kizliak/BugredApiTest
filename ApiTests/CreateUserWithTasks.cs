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
                Companies = new List<int> { 19, 20 },
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
            Thread.Sleep(500);

            var postDataJson = JsonConvert.SerializeObject(createUserWithTasksInput);
            IRestResponse response = requestUrl.SendPostRequest(postDataJson);
            CreateUserWithTasksOutput createUserWithTasksOutput = JsonConvert.DeserializeObject<CreateUserWithTasksOutput>(response.Content);

            Assert.AreEqual(expected: null, actual: createUserWithTasksOutput.type); // если ошибка то будет поле type с текстом ошибки
            Assert.AreEqual(createUserWithTasksInput.Email, createUserWithTasksOutput.email);

            for (int i = 0; i < createUserWithTasksInput.Tasks.Count - 1; i++)
            {
                Assert.AreEqual(createUserWithTasksInput.Tasks[i].Title, createUserWithTasksOutput.tasks[i].name);
            }
            
            Assert.AreEqual(createUserWithTasksInput.Name, createUserWithTasksOutput.name);
            Assert.AreEqual(createUserWithTasksInput.Name1, createUserWithTasksOutput.name1);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
