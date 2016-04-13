using OpenMuseum.Models;

namespace OpenMuseum.Backend.Models.API
{
    public class PointApiViewModel
    {
        public PointApiViewModel(Point point)
        {
            Id = point.Id;
            Name = point.Name;
            Latitude = point.Latitude;
            Longitude = point.Longitude;
        }

        public PointApiViewModel() {}

        public long Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; } 
        public long DataLayerId { get; set; }
    }
}