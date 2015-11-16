using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenMuseum.Backend.Models
{
    public class BaseLayer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool Default { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public virtual ICollection<DataLayer> DataLayers { get; set; }
    }
}