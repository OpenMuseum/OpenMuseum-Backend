using OpenMuseum.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenMuseum.Backend.Controllers
{
    public class PointController : Controller
    {
        // GET: BaseLayers
        public ActionResult Index()
        {
            var pointsRepository = new PointsRepository();
            var points = pointsRepository.GetAll();

            return View(points);
        }

        // GET: BaseLayers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BaseLayers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BaseLayers/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BaseLayers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BaseLayers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BaseLayers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BaseLayers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
