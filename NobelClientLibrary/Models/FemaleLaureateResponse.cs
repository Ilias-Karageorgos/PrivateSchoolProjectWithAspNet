using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NobelClientLibrary
{
    //na ftiakso mia klasi NobelClient
    //mia method get name oti pairno
    //mesa na exei olo ton kodika me to req pou ekana prin
    //apo ASP.net pou exo kato tha xrisimopoiiso to library
    //tha ftiakso neo controller Nobel Controller (empty)
    //na pigaine se adeia selida index pou tha exei koumpi "kane req sto noble api"
    //tha kalei action method pou exei o contr kai tha xrisimopoiei auto to library
    //tha to stelno sto Index san Json ( AJAX REQ GIA TO LIBRARY ME JS)
    //kai na to emfaniso opos einai xoris html css
    //OLA PUBLIC

    public class NobelClient
    {

        static async Task GetFemaleLaureatesBornInGermanyDiedInUsa()
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
                    // Access the data from the deserialized object
                    foreach (var laureate in root.Laureates)
                    {
                        Console.WriteLine($"Name: {laureate.Firstname} {laureate.Surname}");
                        // Access other properties as needed
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
public class FemaleLaureateResponse
{

}
