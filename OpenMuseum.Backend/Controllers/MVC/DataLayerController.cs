using OpenMuseum.Backend.Models;
using OpenMuseum.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenMuseum.Backend.Controllers
{
    public class DataLayerController : Controller
    {
        // GET: BaseLayers
        public ActionResult Index()
        {
            var dataLayersRepository = new DataLayersRepository();

            IDisposable context;
            var layers = dataLayersRepository.GetAll(out context).ToList();

            using (context)
            {
                return View(layers);
            }
        }

        // GET: BaseLayers/Details/5
        public ActionResult Details(long id)
        {
            var dataLayersRepository = new DataLayersRepository();

            var model = dataLayersRepository.GetById(id);

            if (model != null)
                return View(model);
            else
                return HttpNotFound();
        }

        // GET: BaseLayers/Create
        public ActionResult Add()
        {
            var baseLayersRepository = new BaseLayersRepository();
            IDisposable context;

            ViewBag.ListOfBaseLayers = baseLayersRepository.GetAll(out context).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            using (context)
            {
                return View(new DataLayer());
            }
        }

        // POST: BaseLayers/Create
        [HttpPost]
        public ActionResult Add(DataLayer model)
        {
            try
            {
                var dataLayersRepository = new DataLayersRepository();

                dataLayersRepository.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BaseLayers/Edit/5
        public ActionResult Edit(long id)
        {
            var baseLayersRepository = new BaseLayersRepository();
            IDisposable context;

            ViewBag.ListOfBaseLayers = baseLayersRepository.GetAll(out context).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            using (context)
            {
                var dataLayersRepository = new DataLayersRepository();

                var model = dataLayersRepository.GetById(id);

                if (model != null)
                    return View(model);
                else
                    return HttpNotFound();
            }
        }

        // POST: BaseLayers/Edit/5
        [HttpPost]
        public ActionResult Edit(DataLayer model)
        {
            try
            {
                var dataLayersRepository = new DataLayersRepository();

                dataLayersRepository.Update(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: BaseLayers/Delete/5
        public ActionResult Delete(int id)
        {
            var dataLayersRepository = new DataLayersRepository();

            var model = dataLayersRepository.GetById(id);

            if (model != null)
                return View(model);
            else
                return HttpNotFound();
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var dataLayersRepository = new DataLayersRepository();

                dataLayersRepository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
