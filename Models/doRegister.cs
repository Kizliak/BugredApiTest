using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBugredApi.Models
{
    public class DoRegister
    {
        [JsonProperty("email")]
        public string email;

        [JsonProperty("name")]
        public string name;

        [JsonProperty("password")]
        public string password;
    }
}
