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

            foreach (var param in parameters)
            {
                request.AddParameter(param.Key, param.Value);
            }

            IRestResponse response = _client.Execute(request);
            return response;
        }
        public IRestResponse AddAvatar(string email, string avatar)
        {
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json")
                .AddHeader("Content-Type", "multipart/form-data")
                .AddParameter("email", email)
                .AddFile("avatar", avatar)
                .AddParameter("multipart/form-data", "avatar", ParameterType.RequestBody);

            IRestResponse response = _client.Execute(request);
            return response;
        }
        public IRestResponse SendPostRequest(string postBody)
        {
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddJsonBody(postBody);

            IRestResponse response = _client.Execute(request);
            return response;
        }
    }
}
