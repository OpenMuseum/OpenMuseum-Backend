using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenMuseum.Models
{
    public class Point
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long? RegionId { get; set; }
        [ForeignKey("Page")]
        public long? PageId { get; set; }
        
        public virtual Page Page { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<DataLayer> DataLayers { get; set; }
    }
}