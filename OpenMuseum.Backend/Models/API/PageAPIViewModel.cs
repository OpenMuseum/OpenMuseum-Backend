using Newtonsoft.Json;
using OpenMuseum.Models;
using System.Collections.Generic;
using System.Linq;

namespace OpenMuseum.Backend.Models.API
{
    public class PageApiViewModel
    {
        public PageApiViewModel(Page page)
        {
            Id = page.Id;
            Name = page.Name;
            Description = page.Description;
            Content = page.Content;
            Tags = page.Tags?.Select(x => new TagAPIViewModel(x)).ToList();
        }

        public PageApiViewModel() {}

        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; } 

        public List<TagAPIViewModel> Tags { get; set; }
    }
}