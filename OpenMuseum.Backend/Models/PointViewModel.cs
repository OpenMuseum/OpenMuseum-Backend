using OpenMuseum.Models;

namespace OpenMuseum.Backend.Models
{
    public class PointViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; } 

        public PointViewModel(Point point)
        {
            Id = point.Id;
            Name = point.Name;
            Description = point.Description;
            Latitude = point.Longitude;
            Longitude = point.Longitude;
        }
    }
}