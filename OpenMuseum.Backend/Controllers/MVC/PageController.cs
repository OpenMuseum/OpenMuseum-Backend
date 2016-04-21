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
            var pointsRepository = new PointsRepository();
            var regionsRepository = new RegionsRepository();

            var model = pagesRepository.GetById(id);

            var point = pointsRepository.GetByPage(id);
            var region = regionsRepository.GetByPage(id);

            if (model != null)
                return View(new PageViewModel(model, point, region));
            else
                return HttpNotFound();
        }

        // GET: BaseLayers/Create
        public ActionResult Add()
        {
            var regionsRepository = new RegionsRepository();
            IDisposable context = null;

            ViewBag.ListOfRegions = regionsRepository.GetAll(out context).ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            context?.Dispose();

            return View(new PageViewModel(new Page()));
        }

        // POST: BaseLayers/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(PageViewModel model)
        {
            try
            {
                var pagesRepository = new PagesRepository();
                var pointsRepository = new PointsRepository();

                var page = new Page()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Content = model.Content,
                    ExternalId = model.ExternalId
                };

                var pageId = pagesRepository.Add(page);
                model.Point.PageId = pageId;

                pointsRepository.Add(model.Point);

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
            
            var tagsRepository = new TagsRepository();
            IDisposable context = null;

            ViewBag.ListOfTags = tagsRepository.GetAll(out context).ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            context?.Dispose();

            if (model != null)
                return View(new EditPageViewModel(model));
            return HttpNotFound();
        }

        // POST: BaseLayers/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(EditPageViewModel model)
        {
            try
            {
                var tagsRepository = new TagsRepository();
                var tags = tagsRepository.GetByStringIds(model.SelectedTags);

                var pagesRepository = new PagesRepository();
                var originalPage = pagesRepository.GetById(model.Id);

                originalPage.Name = model.Name;
                originalPage.Description = model.Description;
                originalPage.Content = model.Content;
                originalPage.ExternalId = model.ExternalId;
                originalPage.Tags = tags;

                pagesRepository.Update(originalPage);

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
