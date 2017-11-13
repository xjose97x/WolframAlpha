using System;
using Wolfram.Alpha;
using Wolfram.Alpha.Models;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What would you like to search for?");
            string query = Console.ReadLine();
            var service = new WolframAlphaService("YOUR KEY");
            var request = new WolframAlphaRequest
            {
                Input = query
            };
            var x = service.Compute(request).GetAwaiter().GetResult();
            Console.ReadKey();
        }
    }
}
