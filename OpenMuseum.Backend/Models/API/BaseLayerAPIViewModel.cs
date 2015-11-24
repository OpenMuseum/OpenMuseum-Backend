using System.Collections.Generic;
using System.Linq;
using OpenMuseum.Models;

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

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool Default { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public IEnumerable<RegionApiViewModel> Regions { get; set; }
    }
}