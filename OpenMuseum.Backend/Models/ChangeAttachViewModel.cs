using OpenMuseum.Models;
using System.Collections.Generic;
using System.Linq;

namespace OpenMuseum.Backend.Models
{
    public class ChangeAttachViewModel
    {
        public long Id { get; set; }

        public long? PointId { get; set; }
        public long? RegionId { get; set; }
        
        public long? OldPointId { get; set; }
        public long? OldRegionId { get; set; }

        public Region Region { get; set; }
        public Point Point { get; set; }

        public ChangeAttachViewModel() { }
    }
}