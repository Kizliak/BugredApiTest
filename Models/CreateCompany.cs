using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBugredApi.Models
{
    public class CreateCompany
    {
        [JsonProperty("company_name")]
        public string company_name { get; set; }

        [JsonProperty("company_type")]
        public string company_type { get; set; }

        [JsonProperty("company_users")]
        public List<string> company_users { get; set; }

        [JsonProperty("email_owner")]
        public string email_owner { get; set; }
    }
}
