using System;
using System.Web;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using System.Reflection;
using Wolfram.Alpha.Models;
using System.Threading.Tasks;
using Wolfram.Alpha.Attributes;
using System.Collections.Generic;
using Wolfram.Alpha.Models.Conversation;

namespace Wolfram.Alpha
{
    public class WolframAlphaService
    {
        private const string ApiBaseUrl = "https://api.wolframalpha.com/";
        private const string ApiUrl = "v2/query";
        private const string ConversationApiUrl = "v1/conversation.jsp";
        private readonly string appId;

        public WolframAlphaService(string appId)
        {
            if (string.IsNullOrEmpty(appId))
            {
                throw new ArgumentException("Null or empty values are not allowed", nameof(appId));
            }
            this.appId = appId;
        }

        public async Task<WolframAlphaResult> Compute(WolframAlphaRequest request)
        {
            string url = BuildUrl(ApiBaseUrl + ApiUrl, request);
            using(var client = new HttpClient())
            {
                var httpRequest = await client.GetAsync(url);
                var response = await httpRequest.Content.ReadAsStringAsync();
                WolframAlphaResult result = JsonConvert.DeserializeObject<WolframAlphaResult>(response);
                return result;
            }
        }

        public async Task<ConversationResult> Compute(ConversationRequest request)
        {
            string baseUrl = ApiBaseUrl;
            if (!string.IsNullOrWhiteSpace(request?.Host))
            {
                baseUrl = $"https://{request.Host}/api/";
            }
            baseUrl += ConversationApiUrl;
            string url = BuildUrl(baseUrl, request);
            using (var client = new HttpClient())
            {
                var httpRequest = await client.GetAsync(url);
                var response = await httpRequest.Content.ReadAsStringAsync();
                ConversationResult result = JsonConvert.DeserializeObject<ConversationResult>(response);
                return result;
            }
        }

        public async Task<QueryRecognizerResult> QueryRecognizer(string input)
        {
            string url = $"https://www.wolframalpha.com/queryrecognizer/query.jsp?appid={appId}&mode=Default&output=json&i={input}";
            using (var client = new HttpClient())
            {
                var httpRequest = await client.GetAsync(url);
                var response = await httpRequest.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<QueryRecognizerResult>(response);
                return result;
            }
        } 

        private string BuildUrl(string url, object request)
        {
            var type = request.GetType();
            var properties = type.GetProperties();
            var validProperties = properties.Where(p => p.GetValue(request, null) != null).Select(p =>
            {
                var name = p.Name.ToLower();
                var attribute = p.GetCustomAttribute<QueryString>(inherit: true);
                if (attribute != null)
                {
                    name = attribute.Name;
                }
                var value = p.GetValue(request, null);
                var stringValue = value.ToString();                
                if (value is bool)
                {
                    stringValue = value.ToString().ToLower();
                }
                else if (value is List<String> list)
                {
                    stringValue = String.Join(",", list);
                }
                else
                {
                    stringValue = HttpUtility.UrlEncode(stringValue);
                }
                return $"{name}={stringValue}";
            });
            string queryString = String.Join("&", validProperties.ToArray());
            return $"{url}?{queryString}&appid={appId}";
        }
    }
}
