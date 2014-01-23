using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    /// <summary>
    /// This is just a reference app which consumes the nuget library and does something meaningful to test its function.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Wistia.Core.WistiaClient client = new Wistia.Core.WistiaClient(apiKey: "");

            Console.WriteLine("Here is a listing of your Wistia projects:");
            foreach (var project in client.Projects.All().Result)
            {
                Console.WriteLine(project.name);
            }
        }
    }
}
