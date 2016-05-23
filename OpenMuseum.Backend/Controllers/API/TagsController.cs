using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OpenMuseum.Backend.Models;
using OpenMuseum.Backend.Models.API;
using OpenMuseum.Repositories;

namespace OpenMuseum.Backend.Controllers.API
{
    public class TagsController : ApiController
    {
        public IEnumerable<TagAPIViewModel> GetAllTags()
        {
            IDisposable context;

            var tagsRepository = new TagsRepository();
            var tags = tagsRepository.GetAll(out context).ToList();

            var result = tags.Select(tag => new TagAPIViewModel(tag));

            context.Dispose();

            return result;
        }
    }
}
