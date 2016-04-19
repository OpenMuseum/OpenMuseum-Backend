using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenMuseum.Models
{
    public class Region
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Coordinates { get; set; }
        public long BaseLayerId { get; set; }
        [ForeignKey("Page")]
        public long? PageId { get; set; }

        public virtual BaseLayer BaseLayer { get; set; }
        public virtual Page Page { get; set; }
        public virtual ICollection<Point> Points { get; set; }
    }
}