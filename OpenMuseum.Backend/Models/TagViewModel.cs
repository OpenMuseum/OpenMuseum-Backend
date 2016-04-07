using OpenMuseum.Models;

namespace OpenMuseum.Backend.Models
{
    public class TagViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long PageCount { get; set; }

        public TagViewModel(Tag tag)
        {
            Id = tag.Id;
            Name = tag.Name;
            Description = tag.Description;
            PageCount = tag.Pages.Count;
        }
    }
}