using System;
using System.Linq;
using System.Web.Mvc;
using OpenMuseum.Backend.Models;
using OpenMuseum.Models;
using OpenMuseum.Repositories;

namespace OpenMuseum.Backend.Controllers.MVC
{
    public class PointController : Controller
    {
        public ActionResult Index()
        {
            var pointsRepository = new PointsRepository();

            IDisposable context;
            var points = pointsRepository.GetAll(out context).ToList().Select(x => new PointViewModel(x)).ToList();

            using (context)
            {
                return View(points);
            }
        }

        // GET: BaseLayers/Details/5
        public ActionResult Details(long id)
        {
            var pointsRepository = new PointsRepository();

            var model = pointsRepository.GetById(id);

            if (model != null)
                return View(model);
            else
                return HttpNotFound();
        }

        // GET: BaseLayers/Create
        public ActionResult Add()
        {
            var dataLayersRepository = new DataLayersRepository();
            IDisposable context;

            ViewBag.ListOfDataLayers = dataLayersRepository.GetAll(out context).ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            using (context)
            {
                return View(new Point());
            }
        }

        // POST: BaseLayers/Create
        [HttpPost]
        public ActionResult Add(Point model)
        {
            try
            {
                var pointsRepository = new PointsRepository();

                pointsRepository.Add(model);

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
            var dataLayersRepository = new DataLayersRepository();
            IDisposable context;

            ViewBag.ListOfBaseLayers = dataLayersRepository.GetAll(out context).ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            using (context)
            {
                var pointsRepository = new PointsRepository();

                var model = pointsRepository.GetById(id);

                if (model != null)
                    return View(model);
                return HttpNotFound();
            }
        }

        // POST: BaseLayers/Edit/5
        [HttpPost]
        public ActionResult Edit(Point model)
        {
            try
            {
                var pointsRepository = new PointsRepository();

                pointsRepository.Update(model);

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
            var pointsRepository = new PointsRepository();

            var model = pointsRepository.GetById(id);

            if (model != null)
                return View(model);
            return HttpNotFound();
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var pointsRepository = new PointsRepository();

                pointsRepository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
