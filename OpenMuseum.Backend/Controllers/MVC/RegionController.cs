using System;
using System.Linq;
using System.Web.Mvc;
using OpenMuseum.Backend.Models;
using OpenMuseum.Models;
using OpenMuseum.Repositories;

namespace OpenMuseum.Backend.Controllers.MVC
{
    public class RegionController : Controller
    {
        public ActionResult Index()
        {
            var regionsRepository = new RegionsRepository();

            IDisposable context;
            var regions = regionsRepository.GetAll(out context).ToList().Select(x => new RegionViewModel(x)).ToList();

            using (context)
            {
                return View(regions);
            }
        }

        // GET: BaseLayers/Details/5
        public ActionResult Details(long id)
        {
            var regionsRepository = new RegionsRepository();

            var model = regionsRepository.GetById(id);

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

            var baseLayers = baseLayersRepository.GetAll(out context).ToList();

            ViewBag.ListOfBaseLayers = baseLayers.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            ViewBag.BaseLayerUrl = baseLayers.FirstOrDefault()?.Url;

            using (context)
            {
                return View(new Region());
            }
        }

        // POST: BaseLayers/Create
        [HttpPost]
        public ActionResult Add(Region model)
        {
            try
            {
                var regionsRepository = new RegionsRepository();

                regionsRepository.Add(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: BaseLayers/Edit/5
        public ActionResult Edit(long id)
        {
            var baseLayersRepository = new BaseLayersRepository();
            IDisposable context;

            var baseLayers = baseLayersRepository.GetAll(out context).ToList();

            ViewBag.ListOfBaseLayers = baseLayers.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            ViewBag.BaseLayerUrl = baseLayers.FirstOrDefault()?.Url;

            using (context)
            {
                var regionsRepository = new RegionsRepository();

                var model = regionsRepository.GetById(id);

                if (model != null)
                    return View(model);
                return HttpNotFound();
            }
        }

        // POST: BaseLayers/Edit/5
        [HttpPost]
        public ActionResult Edit(Region model)
        {
            try
            {
                var regionsRepository = new RegionsRepository();

                regionsRepository.Update(model);

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
            var regionsRepository = new RegionsRepository();

            var model = regionsRepository.GetById(id);

            if (model != null)
                return View(model);
            return HttpNotFound();
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var regionsRepository = new RegionsRepository();

                regionsRepository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
