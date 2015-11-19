using System.Collections.Generic;
using OpenMuseum.Backend.Models;

namespace OpenMuseum.Models
{
    public class DataLayer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long BaseLayerId { get; set; }

        public virtual BaseLayer BaseLayer { get; set; } 

        public virtual ICollection<Point> Points { get; set; }
    }
}