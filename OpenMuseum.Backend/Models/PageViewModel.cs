using OpenMuseum.Models;
using System.Collections.Generic;
using System.Linq;

namespace OpenMuseum.Backend.Models
{
    public class PageViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string ExternalId { get; set; }
        public long? PointId { get; set; }
        public string PointName { get; set; }
        public long? RegionId { get; set; }
        public string RegionName { get; set; }
        
        public List<TagViewModel> Tags { get; set; }

        public PageViewModel(Page page)
        {
            Id = page.Id;
            Name = page.Name;
            Description = page.Description;
            Content = page.Content;
            ExternalId = page.ExternalId;
            //PointId = page.Point?.Id;
            //PointName = page.Point?.Name;
            //RegionId = page.Region?.Id;
            //RegionName = page.Region?.Name;
            if (page.Tags != null)
                Tags = page.Tags.Select(x => new TagViewModel(x)).ToList();
        }
    }
}