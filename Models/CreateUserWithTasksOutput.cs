using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBugredApi.Models
{
    class CreateUserWithTasksOutput
    {
        [JsonProperty("type")]
        public string type { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("name1")]
        public string name1 { get; set; }

        [JsonProperty("hobby")]
        public string hobby { get; set; }

        [JsonProperty("surname1")]
        public string surname1 { get; set; }

        [JsonProperty("fathername1")]
        public string fathername1 { get; set; }

        [JsonProperty("cat")]
        public string cat { get; set; }

        [JsonProperty("dog")]
        public string dog { get; set; }

        [JsonProperty("parrot")]
        public string parrot { get; set; }

        [JsonProperty("cavy")]
        public string cavy { get; set; }

        [JsonProperty("hamster")]
        public string hamster { get; set; }

        [JsonProperty("squirrel")]
        public string squirrel { get; set; }

        [JsonProperty("phone")]
        public string phone { get; set; }

        [JsonProperty("adres")]
        public string adres { get; set; }

        [JsonProperty("gender")]
        public string gender { get; set; }

        [JsonProperty("date_start")]
        public DateStart date_start { get; set; }

        [JsonProperty("date_updated")]
        public DateUpdated date_updated { get; set; }

        [JsonProperty("birthday")]
        public Birthday birthday { get; set; }

        [JsonProperty("role")]
        public List<string> role { get; set; } = new List<string>();

        [JsonProperty("date_register")]
        public DateRegister date_register { get; set; }

        [JsonProperty("date")]
        public string date { get; set; }

        [JsonProperty("email")]
        public string email { get; set; }

        [JsonProperty("by_user")]
        public string by_user { get; set; }

        [JsonProperty("companies")]
        public List<Company> companies { get; set; } = new List<Company>();

        [JsonProperty("tasks")]
        public List<TaskOutput> tasks { get; set; } = new List<TaskOutput>();
    }

    public class DateStart
    {
        [JsonProperty("sec")]
        public string sec { get; set; }

        [JsonProperty("usec")]
        public string usec { get; set; }
    }

    public class DateUpdated
    {

        [JsonProperty("sec")]
        public string sec { get; set; }

        [JsonProperty("usec")]
        public string usec { get; set; }
    }

    public class Birthday
    {
        [JsonProperty("sec")]
        public string sec { get; set; }

        [JsonProperty("usec")]
        public string usec { get; set; }
    }

    public class DateRegister
    {
        [JsonProperty("sec")]
        public string sec { get; set; }

        [JsonProperty("usec")]
        public string usec { get; set; }
    }

    public class Company
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }
    }

    public class TaskOutput
    {
        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }
    }
}
