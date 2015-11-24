using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OpenMuseum.Backend.Models;
using OpenMuseum.Backend.Models.API;
using OpenMuseum.Repositories;

namespace OpenMuseum.Backend.Controllers.API
{
    public class RegionsController : ApiController
    {
        public IEnumerable<RegionApiViewModel> GetAllRegions()
        {
            IDisposable context;

            var regionsRepository = new RegionsRepository();
            var regions = regionsRepository.GetAll(out context).ToList();

            var result = regions.Select(region => new RegionApiViewModel(region));

            context.Dispose();

            return result;
        }

        public PointApiViewModel GetRegion(long id)
        {
            var pointsRepository = new PointsRepository();
            var model = pointsRepository.GetById(id);

            return new PointApiViewModel(model);
        }
    }
}
