using System;

namespace TestApp
{
    /// <summary>
    /// This is just a reference app which consumes the nuget library and does something meaningful to test its function.
    /// </summary>
    class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            Wistia.Core.WistiaDataClient client = new Wistia.Core.WistiaDataClient(apiKey: "");

            Console.WriteLine("Here is a listing of your Wistia projects:");
            foreach (var project in client.Projects.All().Result)
            {
                Console.WriteLine(project.name);
            }
        }
    }
}
