using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenMuseum.Backend.Models;
using OpenMuseum.Repositories;

namespace OpenMuseum.Backend.Controllers.MVC
{
    public class BaseLayerController : Controller
    {
        // GET: BaseLayers
        public ActionResult Index()
        {
            IDisposable context;

            var baseLayersRepository = new BaseLayersRepository();
            var layers = baseLayersRepository.GetAll(out context).ToList().Select(x => new BaseLayerViewModel(x)).ToList();

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
                        if (IsValidMap(file))
                        {
                            var uniqId = Guid.NewGuid();
                            var fileName = uniqId + Path.GetExtension(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
                            file.SaveAs(path);

                            model.UniqId = uniqId;
                            model.Url = GetCurrentDomain(Request) + "/Public/" + uniqId + "/{z}/{x}/{y}.png";

                            var extractPath = Path.Combine(Server.MapPath("~/Public/"), uniqId.ToString());
                            ZipFile.ExtractToDirectory(path, extractPath);

                            var baseLayersRepository = new BaseLayersRepository();

                            baseLayersRepository.Add(model);

                            return RedirectToAction("Index");
                        }
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public static string GetCurrentDomain(HttpRequestBase request)
        {
            return request.Url.Scheme + Uri.SchemeDelimiter + request.Url.Host +
                (request.Url.IsDefaultPort ? "" : ":" + request.Url.Port);
        }

        private bool IsValidMap(HttpPostedFileBase file)
        {
            return true;
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

                        if (IsValidMap(file))
                        {
                            var uniqId = Guid.NewGuid();
                            var fileName = uniqId + Path.GetExtension(file.FileName);
                            var path = Path.Combine(Server.MapPath("~/App_Data/"), fileName);
                            file.SaveAs(path);

                            model.UniqId = uniqId;
                            model.Url = GetCurrentDomain(Request) + "/Public/" + uniqId + "/{z}/{x}/{y}.png";

                            var extractPath = Path.Combine(Server.MapPath("~/Public/"), uniqId.ToString());
                            ZipFile.ExtractToDirectory(path, extractPath);

                            var baseLayersRepository = new BaseLayersRepository();

                            baseLayersRepository.Add(model);

                            return RedirectToAction("Index");
                        }
                    }
                }

                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
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
