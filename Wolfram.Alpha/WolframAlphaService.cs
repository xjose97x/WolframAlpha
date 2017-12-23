using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using Wolfram.Alpha.Attributes;
using Wolfram.Alpha.Models;

namespace Wolfram.Alpha
{
    public class WolframAlphaService
    {
        private const string ApiUrl = "https://api.wolframalpha.com/v2/query";

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
            string url = BuildUrl(ApiUrl, request);
            using(var client = new HttpClient())
            {
                var httpRequest = await client.GetAsync(url);
                var response = await httpRequest.Content.ReadAsStringAsync();
                WolframAlphaResult result = JsonConvert.DeserializeObject<WolframAlphaResult>(response);
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
