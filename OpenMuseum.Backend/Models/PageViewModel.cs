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

        public Region Region { get; set; }
        public Point Point { get; set; }

        public string[] SelectedTags { get; set; }
        public List<TagViewModel> Tags { get; set; }

        public PageViewModel() { }

        public PageViewModel(Page page)
        {
            Id = page.Id;
            Name = page.Name;
            Description = page.Description;
            Content = page.Content;
            ExternalId = page.ExternalId;
            if (page.Tags != null)
                Tags = page.Tags.Select(x => new TagViewModel(x)).ToList();
        }

        public PageViewModel(Page page, Point point, Region region)
        {
            Id = page.Id;
            Name = page.Name;
            Description = page.Description;
            Content = page.Content;
            ExternalId = page.ExternalId;

            Region = region;
            Point = point;

            PointId = point?.Id;
            PointName = point?.Name;
            RegionId = region?.Id;
            RegionName = region?.Name;

            if (page.Tags != null)
                Tags = page.Tags.Select(x => new TagViewModel(x)).ToList();
        }
    }
}