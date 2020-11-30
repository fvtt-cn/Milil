using System.Text.Json.Serialization;

namespace Milil.Models
{
    public class Sound : BaseObject
    {
        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("repeat")]
        public bool Repeat { get; set; }

        [JsonPropertyName("volume")]
        public double Volume { get; set; }

        [JsonPropertyName("playing")]
        public bool Playing { get; set; }
    }
}
