using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace console02
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Environment.SetEnvironmentVariable("console0_nested:boo", "newvalue");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json")
                .AddEnvironmentVariables("console0_")
                .Build();

            Console.WriteLine("dump configuration");

            foreach (var pair in configuration.AsEnumerable())
            {
                Console.WriteLine("{0}={1}", pair.Key, pair.Value);
            }
        }
    }
}
