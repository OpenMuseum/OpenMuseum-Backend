using System.Collections.Generic;

namespace OpenMuseum.Models
{
    public class Union
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public virtual ICollection<UnionElement> UnionElement { get; set; }
    }
}