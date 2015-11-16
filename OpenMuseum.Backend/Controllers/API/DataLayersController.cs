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

            using (context)
            {
                return layers.Select(layer => new DataLayerAPIViewModel(layer));
            }
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
