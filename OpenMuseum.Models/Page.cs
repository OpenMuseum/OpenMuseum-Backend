using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenMuseum.Models
{
    public class Page
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string ExternalId { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}