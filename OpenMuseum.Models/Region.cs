using OpenMuseum.Backend.Models;

namespace OpenMuseum.Models
{
    public class Region
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Coordinates { get; set; }
        public long BaseLayerId { get; set; }

        public virtual BaseLayer BaseLayer { get; set; }
    }
}