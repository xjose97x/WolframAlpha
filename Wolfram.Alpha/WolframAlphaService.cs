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
using Wolfram.Alpha.Models.QueryRecognizer;
using Wolfram.Alpha.Models.SpokenResults;

namespace Wolfram.Alpha
{
    public class WolframAlphaService
    {
        private const string ApiBaseUrl = "https://api.wolframalpha.com/";
        private const string FullResultsApiUrl = "v2/query";
        private const string ConversationalApiUrl = "v1/conversation.jsp";
        private const string SpokenResultsApiUrl = "v1/spoken";

        private const string FastQueryRecognizerUrl = "http://www.wolframalpha.com/queryrecognizer/query.jsp";

        private readonly string appId;
        
        public WolframAlphaService(string appId)
        {
            if (string.IsNullOrEmpty(appId))
            {
                throw new ArgumentException("Null or empty values are not allowed", nameof(appId));
            }
            this.appId = appId;
        }

        /// <summary>
        /// Makes a Full Results API request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<WolframAlphaResult> Compute(WolframAlphaRequest request)
        {
            string url = BuildUrl(ApiBaseUrl + FullResultsApiUrl, request);
            using(var client = new HttpClient())
            {
                var httpRequest = await client.GetAsync(url);
                var response = await httpRequest.Content.ReadAsStringAsync();
                WolframAlphaResult result = JsonConvert.DeserializeObject<WolframAlphaResult>(response);
                return result;
            }
        }

        /// <summary>
        /// Makes a Conversational API request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<ConversationResult> Compute(ConversationRequest request)
        {
            string baseUrl = ApiBaseUrl;
            if (!string.IsNullOrWhiteSpace(request?.Host))
            {
                baseUrl = $"https://{request.Host}/api/";
            }
            baseUrl += ConversationalApiUrl;
            string url = BuildUrl(baseUrl, request);
            using (var client = new HttpClient())
            {
                var httpRequest = await client.GetAsync(url);
                var response = await httpRequest.Content.ReadAsStringAsync();
                ConversationResult result = JsonConvert.DeserializeObject<ConversationResult>(response);
                return result;
            }
        }

        /// <summary>
        /// Makes a Fast Query Recognizer API request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<QueryRecognizerResult> Compute(QueryRecognizerRequest request)
        {
            string url = BuildUrl(FastQueryRecognizerUrl, request);
            using (var client = new HttpClient())
            {
                var httpRequest = await client.GetAsync(url);
                var response = await httpRequest.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<QueryRecognizerResult>(response);
            }
        }

        /// <summary>
        /// Makes a Spoken API request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<string> Compute(SpokenResultsRequest request)
        {
            string url = BuildUrl($"{ApiBaseUrl}{SpokenResultsApiUrl}", request);
            using (var client = new HttpClient())
            {
                var httpRequest = await client.GetAsync(url);
                var response = await httpRequest.Content.ReadAsStringAsync();
                return response;
            }
        }

        private string BuildUrl(string url, object request)
        {
            var type = request.GetType();
            var properties = type.GetProperties();
            var validProperties = properties.Where(p => p.GetValue(request, null) != null).Select(p =>
            {
                var name = p.Name.ToLower();
                var queryStringAttribute = p.GetCustomAttribute<QueryStringAttribute>(inherit: true);
                if (queryStringAttribute != null)
                {
                    name = queryStringAttribute.Name;
                }
                var value = p.GetValue(request, null);
                var stringValue = value.ToString();                
                if (value is bool)
                {
                    stringValue = value.ToString().ToLower();
                }
                else if (value is List<String> list)
                {
                    var multipleQueryStringParameterAttribute = p.GetCustomAttribute<MultipleQueryStringParameterAttribute>(inherit: true);
                    if (multipleQueryStringParameterAttribute != null)
                    {
                        var q = list.GroupBy(x => x)
                            .Select(x => new
                            {
                                Count = x.Count(),
                                Name = x.Key
                            });
                        string parameters = "";
                        foreach (var item in q)
                        {
                            parameters += $"{name}=";
                            if (item.Count > 1)
                            {
                                parameters += $"{item.Count}@";
                            }
                            parameters += $"{HttpUtility.UrlEncode(item.Name)}&";
                        }
                        return parameters.Remove(parameters.Length - 1);
                    }
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
