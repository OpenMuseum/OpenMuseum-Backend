using System.Collections.Generic;
using System.Linq;
using OpenMuseum.Models;
using Newtonsoft.Json;

namespace OpenMuseum.Backend.Models.API
{
    public class BaseLayerApiViewModel
    {
        public BaseLayerApiViewModel(BaseLayer layer)
        {
            Id = layer.Id;
            Name = layer.Name;
            Description = layer.Description;
            Url = layer.Url;
            Default = layer.Default;
            Height = layer.Height;
            Width = layer.Width;
            Regions = layer.Regions.ToList().Select(region => new RegionApiViewModel(region)).ToList();
        }

        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("default")]
        public bool Default { get; set; }
        [JsonProperty("height")]
        public int Height { get; set; }
        [JsonProperty("width")]
        public int Width { get; set; }
        [JsonProperty("regions")]
        public IEnumerable<RegionApiViewModel> Regions { get; set; }
    }
}