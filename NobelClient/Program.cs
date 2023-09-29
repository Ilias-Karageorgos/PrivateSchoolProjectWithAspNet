using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;



namespace NobelClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:44358/api/Values");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();

                await Console.Out.WriteLineAsync(jsonResponse);
                                               
                var root = JsonSerializer.Deserialize<List<string>>(jsonResponse);

                // Access the data from the parsed object

                if (root != null && root != null)
                {
                    // Access the data from the deserialized object
                    foreach (var str in root)
                    {
                        Console.WriteLine(str);                        
                    }
                }
                else
                {
                    Console.WriteLine("No data found.");
                }
            }
        }
    }
}
