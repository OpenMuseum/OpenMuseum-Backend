using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OpenMuseum.Backend.Models;
using OpenMuseum.Backend.Models.API;
using OpenMuseum.Repositories;

namespace OpenMuseum.Backend.Controllers.API
{
    public class PagesController : ApiController
    {
        public IEnumerable<PageApiViewModel> GetAllPages()
        {
            IDisposable context;

            var pagesRepository = new PagesRepository();
            var pages = pagesRepository.GetAll(out context).ToList();

            var result = pages.Select(page => new PageApiViewModel(page));

            context.Dispose();

            return result;
        }

        public PageApiViewModel GetPage(long id)
        {
            var pagesRepository = new PagesRepository();
            var model = pagesRepository.GetById(id);

            return new PageApiViewModel(model);
        }
    }
}
