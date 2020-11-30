using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Milil.Models
{
    public class SoundPack : Pack
    {
        [JsonPropertyName("mode")]
        public long Mode { get; set; }

        [JsonPropertyName("playing")]
        public bool Playing { get; set; }

        [JsonPropertyName("sounds")]
        public List<Sound> Sounds { get; set; }
    }
}
