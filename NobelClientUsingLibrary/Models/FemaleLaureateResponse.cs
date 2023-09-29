using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NobelClientUsingLibrary.Models
{
    public class FemaleLaureateResponse
    {
        [JsonPropertyName("laureates")]
        public List<Laureate> Laureates { get; set; }
    }
}
