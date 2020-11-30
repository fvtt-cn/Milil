using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Milil.Models
{
    public class Pack : BaseObject
    {
        [JsonPropertyName("permission")]
        public Dictionary<string, int> Permission { get; set; }
    }
}
