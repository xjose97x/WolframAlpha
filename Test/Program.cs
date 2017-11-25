using System;
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
            var request = new WolframAlphaRequest
            {
                Input = "2 pi radians to degrees"
            };
            var result = service.Compute(request).GetAwaiter().GetResult();

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
