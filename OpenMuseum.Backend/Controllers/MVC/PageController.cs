using System;
using System.Linq;
using System.Web.Mvc;
using OpenMuseum.Backend.Models;
using OpenMuseum.Models;
using OpenMuseum.Repositories;
using System.Collections.Generic;

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
        public ActionResult ChangeAttach(long id)
        {
            var regionsRepository = new RegionsRepository();

            var region = regionsRepository.GetByPage(id);

            IDisposable context = null;

            ViewBag.ListOfRegions = regionsRepository.GetAll(out context).ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = region != null && region.Id == x.Id
            });

            context?.Dispose();

            var pointsRepository = new PointsRepository();
            IDisposable context1 = null;

            var point = pointsRepository.GetByPage(id);

            ViewBag.ListOfPoints = pointsRepository.GetAll(out context).ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = point != null && point.Id == x.Id
            });

            context1?.Dispose();

            var model = new ChangeAttachViewModel()
            {
                Id = id,
                OldRegionId = region?.Id,
                OldPointId = point?.Id
            };

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult ChangeAttach(ChangeAttachViewModel model)
        {
            var pageRepository = new PagesRepository();
                var pointRepository = new PointsRepository();
                var regionsRepository = new RegionsRepository();

            var page = pageRepository.GetById(model.Id);

            if (model.PointId.HasValue && model.PointId != model.OldPointId)
            {
                var point = pointRepository.GetById(model.PointId.Value);

                point.PageId = page.Id;
                point.Page = page;

                pointRepository.Update(point);
            }
            else
            {
                if (model.OldPointId.HasValue)
                {
                    var point = pointRepository.GetById(model.OldPointId.Value);

                    point.PageId = null;
                    point.Page = null;

                    pointRepository.Update(point);
                }
            }

            if (model.RegionId.HasValue && model.RegionId != model.OldRegionId)
            {
                var region = regionsRepository.GetById(model.RegionId.Value);

                region.PageId = page.Id;
                region.Page = page;

                regionsRepository.Update(region);
            }
            else
            {
                if (model.OldRegionId.HasValue)
                {
                    var region = regionsRepository.GetById(model.OldRegionId.Value);

                    region.PageId = null;
                    region.Page = null;

                    regionsRepository.Update(region);
                }
            }

            return RedirectToAction("Details", new { id = model.Id });
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
            
            var tagsRepository = new TagsRepository();
            IDisposable context1 = null;

            ViewBag.ListOfTags = tagsRepository.GetAll(out context).ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            context1?.Dispose();


            return View(new PageViewModel(new Page()));
        }

        // POST: BaseLayers/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(PageViewModel model)
        {
            try
            {
                var tagsRepository = new TagsRepository();
                var pointsRepository = new PointsRepository();
                var pagesRepository = new PagesRepository();

                var page = new Page()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Content = model.Content,
                    ExternalId = model.ExternalId
                };

                if (model.SelectedTags != null)
                {
                    var tags = tagsRepository.GetByStringIds(model.SelectedTags);
                    page.Tags = new List<Tag>(tags);
                }
                else
                {
                    page.Tags = null;
                }

                var pageId = pagesRepository.Add(page);
                if (!string.IsNullOrEmpty(model.Point?.Name))
                {
                    model.Point.PageId = pageId;
                    pointsRepository.Add(model.Point);
                }

                if (model.RegionId != null)
                {
                    var regionsRepository = new RegionsRepository();

                    var region = regionsRepository.GetById(model.RegionId.Value);
                    region.Page = null;
                    region.PageId = pageId;

                    regionsRepository.Update(region);
                }

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
            var pagesRepository = new PagesRepository();

            var model = pagesRepository.GetById(id);
            var tagIds = model.Tags != null ? model.Tags.Select(x => x.Id) : new List<long>();
            
            var tagsRepository = new TagsRepository();
            IDisposable context = null;

            ViewBag.ListOfTags = tagsRepository.GetAll(out context).ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = tagIds.Contains(x.Id)
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

                var pagesRepository = new PagesRepository();
                var originalPage = pagesRepository.GetById(model.Id);

                if (model.SelectedTags != null)
                {
                    var tags = tagsRepository.GetByStringIds(model.SelectedTags);
                    originalPage.Tags = new List<Tag>(tags);
                }
                else
                {
                    originalPage.Tags = null;
                }

                originalPage.Name = model.Name;
                originalPage.Description = model.Description;
                originalPage.Content = model.Content;
                originalPage.ExternalId = model.ExternalId;

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
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
