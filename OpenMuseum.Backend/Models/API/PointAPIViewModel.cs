using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenMuseum.Backend.Models
{
    public class PointAPIViewModel
    {
        public PointAPIViewModel(Point point)
        {
            Id = point.Id;
            Name = point.Name;
            Content = point.Content;
            Latitude = point.Latitude;
            Longitude = point.Longitude;
            DataLayerId = point.DataLayerId;
        }

        public PointAPIViewModel() {}

        public long Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; } 
        public long DataLayerId { get; set; }
    }
}