using OpenMuseum.Backend.Models;
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
    public class DataLayersController : ApiController
    {
        // GET: DataLayers
        public IEnumerable<DataLayer> GetAllDataLayers()
        {
            IDisposable context;
            var dataLayersRepository = new DataLayersRepository();
            var layers = dataLayersRepository.GetAll(out context);

            using (context)
            {
                return layers;
            }
        }

        // GET: DataLayer
        public DataLayer GetDataLayer(long id)
        {
            var dataLayersRepository = new DataLayersRepository();
            var model = dataLayersRepository.GetById(id);

            return model;
        }
    }
}
