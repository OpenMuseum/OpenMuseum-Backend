using OpenMuseum.Models;
using System.Collections.Generic;
using System.Linq;

namespace OpenMuseum.Backend.Models
{
    public class EditPointViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long? RegionId { get; set; }
        public long? PageId { get; set; }


        public string[] SelectedDataLayers { get; set; }
        public List<DataLayerViewModel> DataLayers { get; set; }
        public Region Region { get; set; }

        public EditPointViewModel() { }

        public EditPointViewModel(Point point)
        {
            Id = point.Id;
            Name = point.Name;
            Description = point.Description;
            Latitude = point.Longitude;
            Longitude = point.Longitude;
            Region = point.Region;
            PageId = point.PageId;
            RegionId = point.RegionId;
            //DataLayers = point.DataLayers.Select(x => new DataLayerViewModel(x)).ToList();
        }
    }
}