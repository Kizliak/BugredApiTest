using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserBugredApi.Helpers
{
    public class RequestHelper
    {
        private IRestClient _client;
        public RequestHelper(string requestUrl)
        {
            _client = new RestClient(requestUrl);
        }

        public IRestResponse SendGetRequest(Dictionary<string, string> parameters)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("email", "dfdsfdsfdsf");
            request.AddParameter("password", "dgfhdhfj@dfhj.com");

            foreach (var param in parameters)
            {
                request.AddParameter(param.Key, param.Value);
            }

            IRestResponse response = _client.Execute(request);
            return response;
        }
        public IRestResponse SendPostRequest(object postBody)
        {
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(postBody);

            IRestResponse response = _client.Execute(request);
            return response;
        }
    }
}
