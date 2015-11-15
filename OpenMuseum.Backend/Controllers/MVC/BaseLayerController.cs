using OpenMuseum.Backend.Models;
using OpenMuseum.Backend.ViewModels;
using OpenMuseum.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenMuseum.Backend.Controllers
{
    public class BaseLayerController : Controller
    {
        // GET: BaseLayers
        public ActionResult Index()
        {
            IDisposable context;

            var baseLayersRepository = new BaseLayersRepository();
            var layers = baseLayersRepository.GetAll(out context).ToList().Select(x => new BaseLayerViewModel(x));

            using (context)
            {
                return View(layers);
            }
        }

        // GET: BaseLayers/Details/5
        public ActionResult Details(long id)
        {
            var baseLayersRepository = new BaseLayersRepository();

            var model = baseLayersRepository.GetById(id);

            if (model != null)
                return View(model);
            else
                return HttpNotFound();
        }

        // GET: BaseLayers/Create
        public ActionResult Add()
        {
            return View(new BaseLayer());
        }

        // POST: BaseLayers/Create
        [HttpPost]
        public ActionResult Add(BaseLayer model)
        {
            try
            {

                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Data/"), fileName);
                        file.SaveAs(path);

                        model.Url = ResolveServerUrl(Path.Combine("/Data/", fileName), false);
                    }
                }

                var baseLayersRepository = new BaseLayersRepository();

                baseLayersRepository.Add(model);

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

            var model = baseLayersRepository.GetById(id);

            if (model != null)
                return View(model);
            else
                return HttpNotFound();
        }

        // POST: BaseLayers/Edit/5
        [HttpPost]
        public ActionResult Edit(BaseLayer model)
        {
            try
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Data/"), fileName);
                        file.SaveAs(path);

                        model.Url = ResolveServerUrl(Path.Combine("/Data/", fileName), false);
                    }
                }

                var baseLayersRepository = new BaseLayersRepository();

                baseLayersRepository.Update(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public static string ResolveServerUrl(string serverUrl, bool forceHttps)
        {
            if (serverUrl.IndexOf("://") > -1)
                return serverUrl;

            string newUrl = serverUrl;
            Uri originalUri = System.Web.HttpContext.Current.Request.Url;
            newUrl = (forceHttps ? "https" : originalUri.Scheme) +
                "://" + originalUri.Authority + newUrl;
            return newUrl;
        }

        // GET: BaseLayers/Delete/5
        public ActionResult Delete(int id)
        {
            var baseLayersRepository = new BaseLayersRepository();

            var model = baseLayersRepository.GetById(id);

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
                var baseLayersRepository = new BaseLayersRepository();

                baseLayersRepository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
