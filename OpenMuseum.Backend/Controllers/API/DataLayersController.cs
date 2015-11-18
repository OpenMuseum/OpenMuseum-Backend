using OpenMuseum.Backend.Models;
using OpenMuseum.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OpenMuseum.Backend.Controllers
{
    public class DataLayersController : ApiController
    {
        // GET: DataLayers
        public IEnumerable<DataLayerAPIViewModel> GetAllDataLayers()
        {
            IDisposable context;

            var dataLayersRepository = new DataLayersRepository();
            var layers = dataLayersRepository.GetAll(out context).ToList();

            var result = layers.Select(layer => new DataLayerAPIViewModel(layer)
            {
                Points = layer.Points.Select(point => new PointAPIViewModel(point)).ToList()
            }).ToList();

            context.Dispose();

            return result;
        }

        // GET: DataLayer
        public DataLayerAPIViewModel GetDataLayer(long id)
        {
            var dataLayersRepository = new DataLayersRepository();
            var model = dataLayersRepository.GetById(id);

            return new DataLayerAPIViewModel(model);
        }
    }
}
