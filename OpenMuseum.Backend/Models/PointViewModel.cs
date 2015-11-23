using OpenMuseum.Models;

namespace OpenMuseum.Backend.Models
{
    public class PointViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; } 
        public long DataLayerId { get; set; }
        public string DataLayerName { get; set; }

        public PointViewModel(Point point)
        {
            Id = point.Id;
            Name = point.Name;
            Description = point.Description;
            Content = point.Content;
            Latitude = point.Longitude;
            Longitude = point.Longitude;
            DataLayerId = point.DataLayerId;
            DataLayerName = point.DataLayer.Name;
        }
    }
}