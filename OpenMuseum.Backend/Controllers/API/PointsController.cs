using OpenMuseum.Backend.Models;
using OpenMuseum.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OpenMuseum.Backend.Models.API;

namespace OpenMuseum.Backend.Controllers
{
    public class PointsController : ApiController
    {
        // GET: DataLayers
        public IEnumerable<PointApiViewModel> GetAllPoints()
        {
            IDisposable context;

            var pointsRepository = new PointsRepository();
            var points = pointsRepository.GetAll(out context).ToList();

            var result = points.Select(point => new PointApiViewModel(point));

            context.Dispose();

            return result;
        }

        // GET: DataLayer
        public PointApiViewModel GetPoint(long id)
        {
            var pointsRepository = new PointsRepository();
            var model = pointsRepository.GetById(id);

            return new PointApiViewModel(model);
        }
    }
}
