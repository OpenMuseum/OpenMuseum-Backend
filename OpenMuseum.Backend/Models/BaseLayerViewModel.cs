using System.Collections.Generic;
using System.Linq;

namespace OpenMuseum.Backend.Models
{
    public class BaseLayerViewModel
    {
        public BaseLayerViewModel(BaseLayer layer)
        {
            Id = layer.Id;
            Name = layer.Name;
            Description = layer.Description;
            Url = layer.Url;
            if (layer.DataLayers != null)
                DataLayers = layer.DataLayers.ToList().Select(x=> new DataLayerViewModel(x)).ToList();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public List<DataLayerViewModel> DataLayers { get; set; }
    }
}