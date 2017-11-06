using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Wolfram.Alpha.Models;

namespace Wolfram.Alpha
{
    public class WolframAlphaService
    {
        private string apiUrl = "http://api.wolframalpha.com/v2/query?input=pi&appid=&output=json";

        public string AppId { get; set; }

        public WolframAlphaService(string appId)
        {
            AppId = appId;
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


