using OpenMuseum.Backend.ViewModels;
using OpenMuseum.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OpenMuseum.Backend.Controllers
{
    public class BaseLayersController : ApiController
    {
        // GET: BaseLayers
        public IEnumerable<BaseLayerAPIViewModel> GetAllBaseLayers()
        {
            IDisposable context;

            var baseLayersRepository = new BaseLayersRepository();
            var layers = baseLayersRepository.GetAll(out context).ToList();

            using (context)
            {
                return layers.Select(layer => new BaseLayerAPIViewModel(layer));
            }
        }

        // GET: BaseLayer
        public BaseLayerAPIViewModel GetBaseLayer(long id)
        {
            var baseLayersRepository = new BaseLayersRepository();
            var model = baseLayersRepository.GetById(id);

            return new BaseLayerAPIViewModel(model);
        }
    }
}
