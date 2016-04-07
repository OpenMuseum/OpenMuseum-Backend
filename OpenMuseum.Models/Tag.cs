using System.Collections.Generic;

namespace OpenMuseum.Models
{
    public class Tag
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Page> Pages { get; set; }
    }
}