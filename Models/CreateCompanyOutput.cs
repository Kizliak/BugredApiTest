using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBugredApi.Models
{
    class CreateCompanyOutput
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id_company")]
        public int IdCompany { get; set; }

        [JsonProperty("company")]
        public CompanyData companyData { get; set; }
    }

    class CompanyData
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("inn")]
        public string Inn;

        [JsonProperty("ogrn")]
        public string Ogrn;

        [JsonProperty("kpp")]
        public string Kpp;

        [JsonProperty("phone")]
        public string Phone;

        [JsonProperty("adress")]
        public string Adress;

        [JsonProperty("users")]
        public List<string> Users;
    }
}
