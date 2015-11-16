using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenMuseum.Backend.Models
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