using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OpenMuseum.Backend.Models;
using OpenMuseum.Backend.Models.API;
using OpenMuseum.Repositories;

namespace OpenMuseum.Backend.Controllers.API
{
    public class DataLayersController : ApiController
    {
        // GET: DataLayers
        public IEnumerable<DataLayerApiViewModel> GetAllDataLayers()
        {
            IDisposable context;

            var dataLayersRepository = new DataLayersRepository();
            var layers = dataLayersRepository.GetAll(out context).ToList();

            var result = layers.Select(layer => new DataLayerApiViewModel(layer)).ToList();

            context.Dispose();

            return result;
        }

        // GET: DataLayer
        public DataLayerApiViewModel GetDataLayer(long id)
        {
            var dataLayersRepository = new DataLayersRepository();
            var model = dataLayersRepository.GetById(id);

            return new DataLayerApiViewModel(model);
        }
    }
}
