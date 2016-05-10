using System.Collections.Generic;
using System.Linq;
using OpenMuseum.Models;
using Newtonsoft.Json;

namespace OpenMuseum.Backend.Models.API
{
    public class DataLayerApiViewModel
    {
        public DataLayerApiViewModel(DataLayer layer)
        {
            Id = layer.Id;
            Name = layer.Name;
            Description = layer.Description;
            BaseLayerId = layer.BaseLayerId;
            Points = layer.Points?.Select(point => new PointApiViewModel(point)).ToList();
            Children = layer.Children?.Select(point => new DataLayerApiViewModel(point)).ToList();
        }

        public DataLayerApiViewModel()
        { }

        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("baseLayerId")]
        public long BaseLayerId { get; set; }
        [JsonProperty("points")]
        public List<PointApiViewModel> Points { get; set; }
        [JsonProperty("children")]
        public List<DataLayerApiViewModel> Children { get; set; }
    }
}