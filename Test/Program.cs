using System;
using System.Collections.Generic;
using System.Configuration;
using Wolfram.Alpha;
using Wolfram.Alpha.Models;

namespace Test
{
    internal class Program
    {
        public static void Main()
        {
            var apiKey = ConfigurationManager.AppSettings["WolframAlpha.Key"];
            var service = new WolframAlphaService(apiKey);
            var request = new WolframAlphaRequest("C Major")
            {
                Formats = new List<string>
                {
                    Format.Plaintext,
                    Format.Image,
                    Format.Sound
                }
            };

            var result = service.Compute(request).GetAwaiter().GetResult();

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
                Console.ReadKey();
            }
        }
    }
}
