using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenMuseum.Backend.Models
{
    public class BaseLayer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}