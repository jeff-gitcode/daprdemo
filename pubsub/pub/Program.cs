using System.Text;
// See https://aka.ms/new-console-template for more information

namespace pub;

class Program
{
    static readonly HttpClient client = new HttpClient();
    static readonly string daprPort = Environment.GetEnvironmentVariable("DAPR_HTTP_PORT") ?? "3500";

    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        for (int i = 0; i < 10; i++)
        {
            var data = $"{{\"key\": {i}}}";

            Console.WriteLine($"Publishing {data} on port:{daprPort}");

            var content = new StringContent(data, UnicodeEncoding.UTF8, "application/json");

            var response = client.PostAsync($"http://localhost:{daprPort}/v1.0/publish/pubsub/mytopicdemo", content).Result;
        }


    }
}

