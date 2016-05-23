using Newtonsoft.Json;
using OpenMuseum.Models;

namespace OpenMuseum.Backend.Models.API
{
    public class RegionApiViewModel
    {
        public RegionApiViewModel(Region region)
        {
            Id = region.Id;
            Name = region.Name;
            Description = region.Description;
            Coordinates = region.Coordinates;
        }

        public RegionApiViewModel() {}

        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("coordinates")]
        public string Coordinates { get; set; } 
    }
}