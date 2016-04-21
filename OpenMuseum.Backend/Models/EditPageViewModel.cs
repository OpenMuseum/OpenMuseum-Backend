using OpenMuseum.Models;
using System.Collections.Generic;
using System.Linq;

namespace OpenMuseum.Backend.Models
{
    public class EditPageViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string ExternalId { get; set; }

        public string[] SelectedTags { get; set; }
        public List<TagViewModel> Tags { get; set; }

        public EditPageViewModel() { }

        public EditPageViewModel(Page page)
        {
            Id = page.Id;
            Name = page.Name;
            Description = page.Description;
            Content = page.Content;
            ExternalId = page.ExternalId;
            if (page.Tags != null)
                Tags = page.Tags.Select(x => new TagViewModel(x)).ToList();
        }
    }
}