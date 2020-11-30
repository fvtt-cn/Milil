using System.Text.Json.Serialization;

namespace Milil.Models
{
    public class PackFile
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "playlists";

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("entity")]
        public string Entity { get; set; } = "Playlist";
    }
}
