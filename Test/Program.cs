using System;
using Wolfram.Alpha;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new WolframAlphaService("K5JX56-LKP9JK8T69");
            var x = service.Compute().GetAwaiter().GetResult();
            Console.WriteLine("Hello, world!");
            Console.ReadKey();
        }
    }
}
