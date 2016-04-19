﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("PointId")]
        public virtual Point Point { get; set; }
        [ForeignKey("RegionId")]
        public virtual Region Region { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}