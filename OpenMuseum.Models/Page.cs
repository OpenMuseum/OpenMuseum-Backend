using System.Collections.Generic;

namespace OpenMuseum.Models
{
    public class Page
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string ExternalId { get; set; }
        public long? PointId { get; set; }
        public long? RegionId { get; set; }

        public virtual Point Point { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}