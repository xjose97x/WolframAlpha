using System;
using System.Configuration;
using Wolfram.Alpha;
using Wolfram.Alpha.Models.Conversation;

namespace Test
{
    internal class Program
    {
        public static void Main()
        {
            var apiKey = ConfigurationManager.AppSettings["WolframAlpha.Key"];
            var service = new WolframAlphaService(apiKey);
            string s = string.Empty, conversationId = string.Empty, host = string.Empty;
            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                var request = new ConversationRequest
                {
                    i = input
                };
                if (!string.IsNullOrWhiteSpace(s))
                {
                    request.s = s;
                }
                if (!string.IsNullOrWhiteSpace(conversationId))
                {
                    request.conversationid = conversationId;
                }
                if (!string.IsNullOrWhiteSpace(host))
                {
                    request.Host = host;
                }
                var result = service.Compute(request).GetAwaiter().GetResult();
                s = result.S;
                conversationId = result.ConversationId;
                host = result.Host;
               Console.WriteLine(!string.IsNullOrWhiteSpace(result.Error) ? result.Error : result.Result);
            }
        }
    }
}
