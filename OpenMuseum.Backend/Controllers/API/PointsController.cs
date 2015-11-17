using OpenMuseum.Backend.Models;
using OpenMuseum.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OpenMuseum.Backend.Controllers
{
    public class PointsController : ApiController
    {
        // GET: DataLayers
        public IEnumerable<PointAPIViewModel> GetAllPoints()
        {
            IDisposable context;

            var pointsRepository = new PointsRepository();
            var points = pointsRepository.GetAll(out context).ToList();

            var result = points.Select(point => new PointAPIViewModel(point));

            context.Dispose();

            return result;
        }

        // GET: DataLayer
        public PointAPIViewModel GetPoint(long id)
        {
            var pointsRepository = new PointsRepository();
            var model = pointsRepository.GetById(id);

            return new PointAPIViewModel(model);
        }
    }
}
