using System;
using System.Linq;
using System.Web.Mvc;
using OpenMuseum.Backend.Models;
using OpenMuseum.Models;
using OpenMuseum.Repositories;

namespace OpenMuseum.Backend.Controllers.MVC
{
    public class PageController : Controller
    {
        public ActionResult Index()
        {
            var pagesRepository = new PagesRepository();

            IDisposable context;
            var points = pagesRepository.GetAll(out context).ToList().Select(x => new PageViewModel(x)).ToList();

            using (context)
            {
                return View(points);
            }
        }

        // GET: BaseLayers/Details/5
        public ActionResult Details(long id)
        {
            var pagesRepository = new PagesRepository();

            var model = pagesRepository.GetById(id);

            if (model != null)
                return View(model);
            else
                return HttpNotFound();
        }

        // GET: BaseLayers/Create
        public ActionResult Add()
        {
            return View(new Point());
        }

        // POST: BaseLayers/Create
        [HttpPost]
        public ActionResult Add(Page model)
        {
            try
            {
                var pagesRepository = new PagesRepository();

                pagesRepository.Add(model);

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
            var pagesRepository = new PagesRepository();

            var model = pagesRepository.GetById(id);

            if (model != null)
                return View(model);
            return HttpNotFound();
        }

        // POST: BaseLayers/Edit/5
        [HttpPost]
        public ActionResult Edit(Page model)
        {
            try
            {
                var pagesRepository = new PagesRepository();

                pagesRepository.Update(model);

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
            var pagesRepository = new PagesRepository();

            var model = pagesRepository.GetById(id);

            if (model != null)
                return View(model);
            return HttpNotFound();
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var pagesRepository = new PagesRepository();

                pagesRepository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
