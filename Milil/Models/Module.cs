using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Milil.Models
{
    public class Module
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; } = "Milil";

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;

        [JsonPropertyName("version")]
        public string Version { get; set; } = "1.0.0";

        [JsonPropertyName("minimumCoreVersion")]
        public string MinimumCoreVersion { get; set; } = "0.5.0";

        [JsonPropertyName("compatibleCoreVersion")]
        public string CompatibleCoreVersion { get; set; } = "1.0.0";

        [JsonPropertyName("packs")]
        public List<PackFile> Packs { get; set; } = new List<PackFile>();

        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("manifest")]
        public string Manifest { get; set; } = string.Empty;

        [JsonPropertyName("download")]
        public string Download { get; set; } = string.Empty;
    }
}
