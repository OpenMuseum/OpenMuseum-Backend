using Newtonsoft.Json;
using OpenMuseum.Models;
using System.Collections.Generic;

namespace OpenMuseum.Backend.Models.API
{
    public class TagAPIViewModel
    {
        public TagAPIViewModel(Tag tag)
        {
            Id = tag.Id;
            Name = tag.Name;
        }

        public TagAPIViewModel() {}

        [JsonProperty("id")]
        public long Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}