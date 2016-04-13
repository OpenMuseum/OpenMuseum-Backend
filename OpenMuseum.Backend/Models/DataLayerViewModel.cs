using System.Collections.Generic;
using System.Linq;
using OpenMuseum.Models;

namespace OpenMuseum.Backend.Models
{
    public class DataLayerViewModel
    {
        public DataLayerViewModel(DataLayer layer)
        {
            Id = layer.Id;
            Name = layer.Name;
            Description = layer.Description;
            BaseLayerId = layer.BaseLayerId;
            BaseLayerName = layer.BaseLayer.Name;
            if (layer.Points != null)
                Points = layer.Points.ToList().Select(x => new PointViewModel(x)).ToList();
            HasChildren = layer.Children != null && layer.Children.Count > 0;
            if (layer.Children != null)
            {
                Children = layer.Children.ToList().Select(x => new DataLayerViewModel(x)).ToList();
            } 
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long BaseLayerId { get; set; }
        public string BaseLayerName { get; set; }
        public List<PointViewModel> Points { get; set; }
        public bool HasChildren { get; set; }
        public List<DataLayerViewModel> Children { get; set; }
    }
}