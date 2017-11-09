using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Wolfram.Alpha.Models;

namespace Wolfram.Alpha
{
    public class WolframAlphaService
    {
        private const string apiUrl = "https://api.wolframalpha.com/v2/";

        private readonly string appId;

        public WolframAlphaService(string appId)
        {
            if (string.IsNullOrEmpty(appId))
            {
                throw new ArgumentException("Null or empty values are not allowed", nameof(appId));
            }
            this.appId = appId;
        }

        public async Task<WolframResult> Compute(string input = null)
        {
            using(var client = new HttpClient())
            {
                var request = await client.GetAsync(apiUrl);
                var response = await request.Content.ReadAsStringAsync();
                WolframResult result = JsonConvert.DeserializeObject<WolframResult>(response);
                return result;
            }
        }
    }
}
