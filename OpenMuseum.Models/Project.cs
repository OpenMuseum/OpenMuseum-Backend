using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenMuseum.Backend.Models
{
    public class Project
    {
        public long Id { get; set; }
        public Guid UniqId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}