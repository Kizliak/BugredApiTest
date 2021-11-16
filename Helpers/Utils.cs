using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserBugredApi.Models;
using UserBugredApi.Helpers;
using RestSharp;
using Newtonsoft.Json;

namespace UserBugredApi.Helpers
{
    static class Utils
    {
        static public Random rnd = new Random();
        static public string GetNameRandom()
        {
            return "GomoTrio" + rnd.Next(11, 99) + rnd.Next(11, 99) + DateTime.Now.ToString("hhmmssMMddyy");
        }

        static public string GetEmailRandom()
        {
            return DateTime.Now.ToString("hhmmssMMddyy") + rnd.Next(11, 99) + rnd.Next(11, 99) + "@gomotrio.com";
        }

        static public string GetPassword()
        {
            return "mySecretPass123";
        }

        static public void RegisterUserByEmail(DoRegister doRegisterData)
        {
            RequestHelper requestUrl = new RequestHelper("http://users.bugred.ru/tasks/rest/doregister");
            var postDataJson = JsonConvert.SerializeObject(doRegisterData);
            requestUrl.SendPostRequest(postDataJson);
        }
    }
}
