using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OpenMuseum.Models
{
    public class Tag
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Page> Pages { get; set; }
    }
}