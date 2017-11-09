using System;
using Wolfram.Alpha;
using Wolfram.Alpha.Models;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new WolframAlphaService("K5JX56-LKP9JK8T69");
            var request = new WolframRequest
            {
                Input = "pI"
            };
            var x = service.Compute(request).GetAwaiter().GetResult();
            Console.WriteLine("Hello, world!");
            Console.ReadKey();
        }
    }
}
