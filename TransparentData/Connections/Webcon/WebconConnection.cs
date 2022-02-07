using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Threading.Tasks;
using TransparentData.Models.Webcon;

namespace TransparentData.Connections.Webcon
{
    public class WebconConnection: IWebconConnection
    {
        private readonly ILogger _logger;
        private readonly string _token = null;
        private readonly string _urlMain = null;
        private readonly RestClient _restClient = null;
        private readonly string _urlElements = "api/data/v3.0/db/1/elements";

        //CONFIGURATION
        public WebconConnection(ILogger<WebconConnection> logger, IOptions<Authorization> auth)
        {
            _logger = logger;
            _urlMain = auth.Value.Url;
            _restClient = new RestClient(_urlMain);
            _token = GetToken(auth);

        }

        private string GetToken(IOptions<Authorization> auth)
        {
            var body = JsonConvert.SerializeObject(auth.Value, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var requestToken = new RestRequest("api/login", Method.POST);
            requestToken.AddHeader("Accept", "application/json");
            requestToken.AddHeader("Content-type", "application/json");
            requestToken.AddParameter("application/json", body, ParameterType.RequestBody);
            var response = _restClient.Execute(requestToken);
            var responseObj = JObject.Parse(response.Content);
            return (string)responseObj["token"];
        }

        private async Task<string> Execute(string url, Method method = Method.GET, object obj = null)
        {
            _logger.LogInformation($"Start request {url}");
            var body = JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var restRequest = new RestRequest(url, method);
            restRequest.AddHeader("Content-Type", "application/json-patch+json");
            restRequest.AddHeader("Authorization", $"Bearer {_token}");
            restRequest.AddHeader("accept", "application/json");
            if (obj != null)
                restRequest.AddJsonBody(body);
            var result = await _restClient.ExecuteAsync(restRequest);
            if (!result.IsSuccessful)
            {
                _logger.LogError($"{result.StatusCode}: {result.ErrorMessage}");
                throw new InvalidOperationException();
            }
            _logger.LogInformation($"Success request {url}");
            return result.Content;
        }


        public Element GetElement(int elementID)
        {
            var content = Execute($"{ _urlElements}/{ elementID}").Result;
            return JsonConvert.DeserializeObject<Element>(content);
        }

        public Responce PatchElement(int elementID, Element element)
        {
            var content = Execute($"{_urlMain}{ _urlElements}/{ elementID}", Method.PATCH, element).Result;
            return JsonConvert.DeserializeObject<Responce>(content);
        }

        public Responce PostAttachment(int elementID, Attachment element)
        {
            var content = Execute($"{_urlMain}{ _urlElements}/{ elementID}/attachments", Method.POST, element).Result;
            return JsonConvert.DeserializeObject<Responce>(content);
        }
    }

}
