using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBugredApi.Models
{
    public class CreateUser
    {
        [JsonProperty("email")]
        public string email;

        [JsonProperty("name")]
        public string name;

        [JsonProperty("tasks")]
        List<string> tasks;

        [JsonProperty("companies")]
        List<string> companies;

        [JsonProperty("hobby")]
        public string hobby;

        [JsonProperty("adres")]
        public string adres;

        [JsonProperty("name1")]
        public string name1;

        [JsonProperty("surname1")]
        public string surname1;

        [JsonProperty("fathername1")]
        public string fathername1;

        [JsonProperty("cat")]
        public string cat;

        [JsonProperty("dog")]
        public string dog;

        [JsonProperty("parrot")]
        public string parrot;

        [JsonProperty("cavy")]
        public string cavy;

        [JsonProperty("hamster")]
        public string hamster;

        [JsonProperty("squirrel")]
        public string squirrel;

        [JsonProperty("phone")]
        public string phone;

        [JsonProperty("inn")]
        public string inn;

        [JsonProperty("gender")]
        public string gender;

        [JsonProperty("birthday")]
        public string birthday;
        [JsonProperty("date_start")]
        public string date_start;
    }
}
