using System;
using Wolfram.Alpha;
using Wolfram.Alpha.Models;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new WolframAlphaService("YOUR API KEY");
            var request = new WolframAlphaRequest
            {
                Input = "2 pi radians to degrees"
            };
            var x = service.Compute(request).GetAwaiter().GetResult();
            Console.ReadKey();
        }
    }
}
