using System.Text.Json;
using System.Text.Json.Serialization;
namespace OneListClient
{
    public class Vehicle
    {
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("model")]
        public string model { get; set; }
        [JsonPropertyName("manufacturer")]
        public string manufacturer { get; set; }
        [JsonPropertyName("crew")]
        public string crew { get; set; }
        [JsonPropertyName("length")]
        public string length { get; set; }

    }
}