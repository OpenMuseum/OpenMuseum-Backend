using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenMuseum.Backend.Models
{
    public class Point
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; } 
    }
}