using System.Collections.Generic;
using System.Linq;
using OpenMuseum.Models;

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
            Points = layer.Points.ToList().Select(point => new PointApiViewModel(point)).ToList();
        }

        public DataLayerApiViewModel()
        { }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long BaseLayerId { get; set; }

        public IEnumerable<PointApiViewModel> Points { get; set; }
    }
}