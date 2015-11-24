namespace OpenMuseum.Models
{
    public class UnionElement
    {
        public long Id { get; set; }
        public int Weight { get; set; }
        public long PointId { get; set; }

        public virtual Point Point { get; set; }
    }
}