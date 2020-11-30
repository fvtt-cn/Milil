using System.Text.Json.Serialization;

namespace Milil.Models
{
    public class BaseObject
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("flags")]
        public Flags Flags { get; set; } = new Flags();
    }
}
