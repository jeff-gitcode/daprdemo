using Grpc.Core;
using Grpc.Net.Client;
using grpcserver;

class Program
{
    static async Task Main()
    {
        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

        var port = Environment.GetEnvironmentVariable("DAPR_GRPC_PORT") ?? "5011";

        var channel = GrpcChannel.ForAddress($"http://localhost:{port}");

        var client = new Greeter.GreeterClient(channel);

        var metadata = new Metadata { { "dapr-app-id", "grpcserver" } };

        var request = new HelloRequest { Name = "Jeff" };

        var response = await client.SayHelloAsync(request, metadata);

        Console.WriteLine("Greeting: ");
        Console.WriteLine(response);
    }
}
