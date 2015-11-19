using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenMuseum.Models;

namespace OpenMuseum.Backend.Models
{
    public class DataLayerAPIViewModel
    {
        public DataLayerAPIViewModel(DataLayer layer)
        {
            Id = layer.Id;
            Name = layer.Name;
            Description = layer.Description;
            BaseLayerId = layer.BaseLayerId;
        }

        public DataLayerAPIViewModel()
        { }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long BaseLayerId { get; set; }

        public IEnumerable<PointAPIViewModel> Points { get; set; }
    }
}