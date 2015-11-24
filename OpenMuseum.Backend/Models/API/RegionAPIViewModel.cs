using OpenMuseum.Models;

namespace OpenMuseum.Backend.Models.API
{
    public class RegionApiViewModel
    {
        public RegionApiViewModel(Region region)
        {
            Id = region.Id;
            Name = region.Name;
            Description = region.Description;
            Content = region.Content;
            Coordinates = region.Coordinates;
            BaseLayerId = region.BaseLayerId;
        }

        public RegionApiViewModel() {}

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Coordinates { get; set; } 
        public long BaseLayerId { get; set; }
    }
}