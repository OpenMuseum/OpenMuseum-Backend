using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using OpenMuseum.Backend.Models.API;
using OpenMuseum.Repositories;

namespace OpenMuseum.Backend.Controllers.API
{
    public class BaseLayersController : ApiController
    {
        // GET: BaseLayers
        public IEnumerable<BaseLayerApiViewModel> GetAllBaseLayers()
        {
            IDisposable context;

            var baseLayersRepository = new BaseLayersRepository();
            var layers = baseLayersRepository.GetAll(out context).ToList();

            using (context)
            {
                return layers.Select(layer => new BaseLayerApiViewModel(layer));
            }
        }

        // GET: BaseLayer
        public BaseLayerApiViewModel GetBaseLayer(long id)
        {
            var baseLayersRepository = new BaseLayersRepository();
            var model = baseLayersRepository.GetById(id);

            return new BaseLayerApiViewModel(model);
        }
    }
}
