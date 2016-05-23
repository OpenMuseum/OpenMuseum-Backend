using Newtonsoft.Json;
using OpenMuseum.Models;
using System.Collections.Generic;
using System.Linq;

namespace OpenMuseum.Backend.Models.API
{
    public class PointApiViewModel
    {
        public PointApiViewModel(Point point)
        {
            Id = point.Id;
            Name = point.Name;
            Description = point.Description;
            Coordinates = point.Coordinates;
            DataLayersId = point.DataLayers?.Select(x => x.Id).ToList();
            PageId = point.PageId;
            RegionId = point.RegionId;
        }

        public PointApiViewModel() {}

        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("coordinates")]
        public string Coordinates { get; set; }
        [JsonProperty("dataLayerId")]
        public List<long> DataLayersId { get; set; }
        [JsonProperty("regionId")]
        public long? RegionId { get; set; }
        [JsonProperty("pageId")]
        public long? PageId { get; set; }
    }
}