using System;
using System.Linq;
using System.Web.Mvc;
using OpenMuseum.Backend.Models;
using OpenMuseum.Models;
using OpenMuseum.Repositories;

namespace OpenMuseum.Backend.Controllers.MVC
{
    public class TagController : Controller
    {
        public ActionResult Index()
        {
            var tagsRepository = new TagsRepository();

            IDisposable context;
            var tags = tagsRepository.GetAll(out context).ToList().Select(x => new TagViewModel(x)).ToList();

            using (context)
            {
                return View(tags);
            }
        }

        // GET: BaseLayers/Details/5
        public ActionResult Details(long id)
        {
            var tagsRepository = new TagsRepository();

            var model = tagsRepository.GetById(id);

            if (model != null)
                return View(model);
            else
                return HttpNotFound();
        }

        // GET: BaseLayers/Create
        public ActionResult Add()
        {
            return View(new Tag());
        }

        // POST: BaseLayers/Create
        [HttpPost]
        public ActionResult Add(Tag model)
        {
            try
            {
                var tagsRepository = new TagsRepository();

                tagsRepository.Add(model);

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
            var tagsRepository = new TagsRepository();

            var model = tagsRepository.GetById(id);

            if (model != null)
                return View(model);
            return HttpNotFound();
        }

        // POST: BaseLayers/Edit/5
        [HttpPost]
        public ActionResult Edit(Tag model)
        {
            try
            {
                var tagsRepository = new TagsRepository();

                tagsRepository.Update(model);

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
            var tagsRepository = new TagsRepository();

            var model = tagsRepository.GetById(id);

            if (model != null)
                return View(model);
            return HttpNotFound();
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var tagsRepository = new TagsRepository();

                tagsRepository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
