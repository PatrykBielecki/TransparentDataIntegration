using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransparentData.Models;
using Microsoft.Extensions.Logging;

namespace TransparentData
{
    public class TDConnection : ITDConnection
    {
        readonly RestClient _restClient;

        public TDConnection(ILogger<TDConnection> logger, IOptions<Account> options) 
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            var account = options.Value;
            _restClient = new RestClient(account.Url)
            {
                Authenticator = new HttpBasicAuthenticator(account.Username, account.Password)
            };
        }

        public async Task<JObject> Execute(Request body) 
        {

            var responceFromAdd = await QueryAdd(
                JsonConvert.SerializeObject(body, Formatting.None, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }));

            if (responceFromAdd.Status == "error")
                throw new Exception($"Error form responce - {responceFromAdd.Message}");

            var content = await QueryResult(responceFromAdd.Ident);

            return content;
        }

        public async Task<ResponceFromAdd> QueryAdd(string body)
        {
            var request = new RestRequest("add", Method.POST);
            request.AddJsonBody(body);
            var responce = await _restClient.ExecuteAsync(request);
            if (responce.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception($"Error - {JsonConvert.DeserializeObject<ResponceFromAdd>(responce.Content).Message}");

            return JsonConvert.DeserializeObject<ResponceFromAdd>(responce.Content);
        }

        public async Task<JObject> QueryResult(string ident)
        {
            JObject obj;
            string status;
            int time = 2000;
            do
            {
                await Task.Delay(time);
                var request = new RestRequest("result", Method.GET);
                request.AddParameter("ident", ident);
                var responce = await _restClient.ExecuteAsync(request);
                if (responce.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception($"Error - {responce.ErrorMessage}");
                obj = JObject.Parse(responce.Content);
                status = obj["status"].ToString();
                time *= 2;
                if (time / 1000 > 1100) return null;
            } while (status == "quened" || status == "in_progress");
            return obj;
        }

    }
}
