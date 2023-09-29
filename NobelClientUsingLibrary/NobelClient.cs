using NobelClientUsingLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NobelClientUsingLibrary
{
    public class NobelClient
    {       
        public static async Task<string> GetAllFemaleLaureatesBornInGerDiedInUsa()
        {
            using (HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.nobelprize.org/v1/laureate.json?bornCountry=germany&diedCountry=usa&gender=female");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonResponse = await response.Content.ReadAsStringAsync();


                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true, // To make property name matching case-insensitive
                };

                // Parse the JSON manually
                var root = JsonSerializer.Deserialize<FemaleLaureateResponse>(jsonResponse, options);
                // Access the data from the parsed object

                if (root != null && root.Laureates != null)
                {                    
                    return jsonResponse;
                }
                else
                {
                    Console.WriteLine("No data found.");
                    return null;
                }
            }
        }
    }
}
