namespace OpenMuseum.Models
{
    public class Point
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; } 
        public long DataLayerId { get; set; }

        public virtual DataLayer DataLayer { get; set; }
    }
}