using System;
using OneListClient.Models;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using System.Collections.Generic;
using ConsoleTables;

namespace OneListClient
{

    class Program
    {
        static async Task ShowAllItems(string token)
        {
            var client = new HttpClient();
            var url = "https://one-list-api.herokuapp.com/items?access_token={token}";
            var responseAsStream = await client.GetStreamAsync(url);
            // Supply that *stream of data* to a Deserialize that will interpret it as a List of Item objects.
            var items = await JsonSerializer.DeserializeAsync<List<Item>>(responseAsStream);
            var table = new ConsoleTable("ID", "Description", "Created At", "Completed");
            // For each item in our deserialized List of Item
            foreach (var item in items)
            {
                // Add one row to our table
                table.AddRow(item.Id, item.Text, item.CreatedAt, item.CompletedStatus);
            }
            // Write the table
            table.Write(Format.Minimal);
        }


        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            var responseAsStream = await client.GetStreamAsync("https://swapi.dev/api/planets/");
            var planets = await JsonSerializer.DeserializeAsync<PlanetContainer>(responseAsStream);
            var table = new ConsoleTable("Name", "Gravity", "Climate");

            foreach (var planet in planets.results)
            {
                table.AddRow(planet.name, planet.gravity, planet.climate);
            }
            table.Write();


        }
    }
}
