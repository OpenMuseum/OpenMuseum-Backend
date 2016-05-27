using System;
using System.Linq;
using System.Web.Mvc;
using OpenMuseum.Backend.Models;
using OpenMuseum.Models;
using OpenMuseum.Repositories;
using System.Collections.Generic;

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

            var baseLayersRepository = new BaseLayersRepository();
            IDisposable context3;

            var baseLayers = baseLayersRepository.GetAll(out context3).ToList();

            ViewBag.BaseLayerUrl = baseLayers.FirstOrDefault()?.Url;
            context3?.Dispose();

            if (model != null)
                return View(model);
            else
                return HttpNotFound();
        }

        // GET: BaseLayers/Create
        public ActionResult ChangeAttach(long id)
        {
            var pagesRepository = new PagesRepository();
            var pointsRepository = new PointsRepository();

            var point = pointsRepository.GetById(id);

            IDisposable context = null;

            ViewBag.ListOfPages = pagesRepository.GetAll(out context).ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = point != null && point.PageId == x.Id
            });

            context?.Dispose();

            var model = new ChangeAttachPageViewModel()
            {
                Id = id,
                OldPageId = point?.PageId
            };

            return PartialView(model);
        }

        [HttpPost]
        public ActionResult ChangeAttach(ChangeAttachPageViewModel model)
        {
            var pageRepository = new PagesRepository();
            var pointRepository = new PointsRepository();

            var point = pointRepository.GetById(model.Id);

            if (model.PageId.HasValue && model.PageId != point.PageId)
            {
                var page = pageRepository.GetById(model.PageId.Value);

                point.PageId = page.Id;
                point.Page = page;

                pointRepository.Update(point);
            }
            else
            {
                if (model.OldPageId.HasValue)
                {
                    point.PageId = null;
                    point.Page = null;

                    pointRepository.Update(point);
                }
            }

            return RedirectToAction("Details", new { id = model.Id });
        }

        // GET: BaseLayers/Create
        public ActionResult Add()
        {
            var dataLayersRepository = new DataLayersRepository();
            var regionsRepository = new RegionsRepository();

            IDisposable context = null;

            ViewBag.ListOfRegions = regionsRepository.GetAll(out context).ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            context?.Dispose();

            var baseLayersRepository = new BaseLayersRepository();
            IDisposable context3;

            var baseLayers = baseLayersRepository.GetAll(out context3).ToList();

            ViewBag.BaseLayerUrl = baseLayers.FirstOrDefault()?.Url;
            context3?.Dispose();

            IDisposable context1;

            ViewBag.ListOfDataLayers = dataLayersRepository.GetAll(out context1).ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            using (context1)
            {
                return View(new EditPointViewModel(new Point()));
            }
        }

        // POST: BaseLayers/Create
        [HttpPost]
        public ActionResult Add(EditPointViewModel model)
        {
            try
            {
                var pointsRepository = new PointsRepository();
                var dataLayersRepository = new DataLayersRepository();


                var point = new Point()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    Coordinates = model.Coordinates,
                    PageId = model.PageId,
                    RegionId = model.RegionId
                };

                if (model.SelectedDataLayers != null)
                {
                    var dataLayers = dataLayersRepository.GetByStringIds(model.SelectedDataLayers);
                    point.DataLayers = new List<DataLayer>(dataLayers);
                }
                else
                {
                    point.DataLayers = null;
                }

                pointsRepository.Add(point);

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
            var pointsRepository = new PointsRepository();
            var regionsRepository = new RegionsRepository();

            var model = pointsRepository.GetById(id);
            var dataLayersIds = model.DataLayers != null ? model.DataLayers.Select(x => x.Id) : new List<long>();

            IDisposable context;

            ViewBag.ListOfDataLayers = dataLayersRepository.GetAll(out context).ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = dataLayersIds.Contains(x.Id)
            });

            context?.Dispose();

            IDisposable context1 = null;

            ViewBag.ListOfRegions = regionsRepository.GetAll(out context1).ToList().Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });

            context1?.Dispose();

            var baseLayersRepository = new BaseLayersRepository();
            IDisposable context3;

            var baseLayers = baseLayersRepository.GetAll(out context3).ToList();

            ViewBag.BaseLayerUrl = baseLayers.FirstOrDefault()?.Url;
            context3?.Dispose();

            if (model != null)
                return View(new EditPointViewModel(model));
            return HttpNotFound();
        }

        // POST: BaseLayers/Edit/5
        [HttpPost]
        public ActionResult Edit(EditPointViewModel model)
        {
            try
            {
                var dataLayersRepository = new DataLayersRepository();

                var pointsRepository = new PointsRepository();
                var originalPoint = pointsRepository.GetById(model.Id);

                if (model.SelectedDataLayers != null)
                {
                    var dataLayers = dataLayersRepository.GetByStringIds(model.SelectedDataLayers);
                    originalPoint.DataLayers = new List<DataLayer>(dataLayers);
                }
                else
                {
                    originalPoint.DataLayers = null;
                }

                originalPoint.Name = model.Name;
                originalPoint.Description = model.Description;
                originalPoint.Latitude = model.Latitude;
                originalPoint.Longitude = model.Longitude;
                originalPoint.PageId = model.PageId;
                originalPoint.RegionId = model.RegionId;
                originalPoint.Coordinates = model.Coordinates;

                pointsRepository.Update(originalPoint);

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
