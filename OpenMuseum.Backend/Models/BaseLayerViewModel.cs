using OpenMuseum.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenMuseum.Backend.ViewModels
{
    public class BaseLayerViewModel
    {
        public BaseLayerViewModel(BaseLayer layer)
        {
            Id = layer.Id;
            Name = layer.Name;
            Description = layer.Description;
            Url = layer.Url;
            DataLayers = layer.DataLayers.ToList();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public List<DataLayer> DataLayers { get; set; }
    }
}