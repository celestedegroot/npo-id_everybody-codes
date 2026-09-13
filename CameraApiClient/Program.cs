using System.Net.Http.Headers;
using System.Net.Http.Json;
using Microsoft.VisualBasic;

class Program
{
    static async Task Main(string[] args)
    {
        if (args.Length >= 1)
        {
            if (args.Length == 2)
            {
                if (args[0] == "--name")
                {
                    using HttpClient client = new();
                    client.DefaultRequestHeaders.Accept.Clear();

                    await FindCamerasByName(client, args[1]);
                }
                
                else Console.WriteLine("Unknown option\n\ntry 'dotnet run --help'");
            }

            if (args[0] == "--help") Console.WriteLine("Usage: dotnet run [OPTION]\n\nOptions:\n--name: searches camera by name");
            else Console.WriteLine("Unknown option\n\ntry 'dotnet run --help'");
        }

        else Console.WriteLine("No option provided\n\ntry 'dotnet run --help'");
    }

    static async Task FindCamerasByName(HttpClient client, string name)
    {
        var cameras = await client.GetFromJsonAsync<List<Camera>>("http://localhost:5111/csvfile");

        foreach (var camera in cameras ?? Enumerable.Empty<Camera>())
        {
            if (camera.Name.Contains(name)) Console.WriteLine(camera);
        }
    }
}