using System.Collections.Generic;

namespace OpenMuseum.Models
{
    public class DataLayer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long BaseLayerId { get; set; }
        public long? ParentId { get; set; }

        public virtual BaseLayer BaseLayer { get; set; } 
        public virtual DataLayer Parent { get; set; } 

        public virtual ICollection<Point> Points { get; set; }

        public virtual ICollection<DataLayer> Children { get; set; }
    }
}