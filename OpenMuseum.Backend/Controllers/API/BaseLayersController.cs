using OpenMuseum.Backend.Models;
using OpenMuseum.Backend.ViewModels;
using OpenMuseum.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OpenMuseum.Backend.Controllers
{
    public class BaseLayersController : ApiController
    {
        // GET: BaseLayers
        public IEnumerable<BaseLayerViewModel> GetAllBaseLayers()
        {
            IDisposable context;

            var baseLayersRepository = new BaseLayersRepository();
            var layers = baseLayersRepository.GetAll(out context).ToList();

            using (context)
            {
                return layers.Select(layer => new BaseLayerViewModel(layer));
            }
        }

        // GET: BaseLayer
        public BaseLayer GetBaseLayer(long id)
        {
            var baseLayersRepository = new BaseLayersRepository();
            var model = baseLayersRepository.GetById(id);

            return model;
        }
    }
}
