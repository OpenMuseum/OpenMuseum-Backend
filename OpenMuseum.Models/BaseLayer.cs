using System;
using System.Collections.Generic;

namespace OpenMuseum.Models
{
    public class BaseLayer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UniqId { get; set; }
        public bool Default { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public string Url { get; set; }

        public virtual ICollection<DataLayer> DataLayers { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
    }
}