using System;
using Wolfram.Alpha;
using System.Configuration;
using Wolfram.Alpha.Models;
using System.Collections.Generic;
using Wolfram.Alpha.Models.Conversation;

namespace Test
{
    internal class Program
    {
        private static readonly string apiKey = ConfigurationManager.AppSettings["WolframAlpha.Key"];
        private static readonly WolframAlphaService service = new WolframAlphaService(apiKey);

        public static void Main()
        {
            int apiOption;
            do
            {
                Console.WriteLine("*** WOLFRAM ALPHA .NET ***");
                Console.WriteLine("1.Full Results API");
                Console.WriteLine("2.Conversational API");
                apiOption = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            } while (apiOption > 2 || apiOption < 1);

            switch (apiOption)
            {
                case 1:
                {
                    FullResults();
                    break;
                }
                case 2:
                {
                    Conversational();
                    break;
                }
            }
        }

        private static void FullResults()
        {
            Console.WriteLine("What would you like to search for?");
            string input = Console.ReadLine();
            var request = new WolframAlphaRequest(input)
            {
                Formats = new List<string>
                {
                    Format.Plaintext,
                    Format.Image,
                    Format.Sound
                }
            };

            var result = service.Compute(request).GetAwaiter().GetResult();

            if (result.QueryResult.Error != null)
            {
                Console.WriteLine(result.QueryResult.Error.Message);
            }

            if (result.QueryResult.Pods != null)
            {
                foreach (var pod in result.QueryResult.Pods)
                {
                    if (pod.SubPods != null)
                    {
                        Console.WriteLine(pod.Title);
                        foreach (var subpod in pod.SubPods)
                        {
                            Console.WriteLine("    " + subpod.Plaintext);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No results were found!");
            }
            Console.ReadKey();
        }

        private static void Conversational()
        {
            string s = string.Empty, conversationId = string.Empty, host = string.Empty;
            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                var request = new ConversationRequest
                {
                    I = input
                };
                if (!string.IsNullOrWhiteSpace(s))
                {
                    request.S = s;
                }
                if (!string.IsNullOrWhiteSpace(conversationId))
                {
                    request.Conversationid = conversationId;
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