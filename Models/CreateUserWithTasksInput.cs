using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBugredApi.Models
{
    class CreateUserWithTasksInput
    {
        [JsonProperty("email")]
        public string Email;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("tasks")]
        public List<Task> Tasks;

        [JsonProperty("companies")]
        public List<int> Companies;

        [JsonProperty("hobby")]
        public string Hobby;

        [JsonProperty("adres")]
        public string Adres;

        [JsonProperty("name1")]
        public string Name1;

        [JsonProperty("surname1")]
        public string Surname1;

        [JsonProperty("fathername1")]
        public string Fathername1;

        [JsonProperty("cat")]
        public string Cat;

        [JsonProperty("dog")]
        public string Dog;

        [JsonProperty("parrot")]
        public string Parrot;

        [JsonProperty("cavy")]
        public string Cavy;

        [JsonProperty("hamster")]
        public string Hamster;

        [JsonProperty("squirrel")]
        public string Squirrel;

        [JsonProperty("phone")]
        public string Phone;

        [JsonProperty("inn")]
        public string Inn;

        [JsonProperty("gender")]
        public string Gender;

        [JsonProperty("birthday")]
        public string Birthday;

        [JsonProperty("date_start")]
        public string Date_start;
    }

    public class Task
    {
        [JsonProperty("title")]
        public string Title;

        [JsonProperty("description")]
        public string Description;
    }
}
