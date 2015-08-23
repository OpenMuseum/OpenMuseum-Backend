using Newtonsoft.Json;

namespace OpenMuseum_Backend.Models
{
    public class Layer
    {
        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("url")]
        public string TileUrl { get; set; }
    }
}