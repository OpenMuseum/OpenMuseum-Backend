using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenMuseum.Models;

namespace OpenMuseum.Repositories
{
    public class PointsRepository
    {
        public IEnumerable<Point> GetAll(out IDisposable context)
        {
            var db = new OpenMuseumContext();
            context = db;

            return db.Points.Include(x => x.DataLayers);
        }

        public Point GetById(long id)
        {
            using (var context = new OpenMuseumContext())
            {
                var model = context.Points.Include(x => x.DataLayers).Include(x => x.Region).Include(x => x.Page).FirstOrDefault(x => x.Id == id);

                return model;
            }
        }

        public Point GetByPage(long pageId)
        {
            using (var context = new OpenMuseumContext())
            {
                var model = context.Points.Include(x => x.DataLayers).Include(x => x.Region).Include(x => x.Page).FirstOrDefault(x => x.PageId == pageId);

                return model;
            }
        }

        public long Add(Point model)
        {
            using (var context = new OpenMuseumContext())
            {
                if (model.DataLayers != null)
                {
                    var dataLayers = model.DataLayers.ToList();
                    model.DataLayers = new List<DataLayer>();

                    foreach (var dataLayer in dataLayers)
                    {
                        context.DataLayers.Attach(dataLayer);
                        model.DataLayers.Add(dataLayer);
                    }
                }

                var result = context.Points.Add(model);
                context.Entry(result).State = EntityState.Added;
                context.SaveChanges();

                return result.Id;
            }
        }

        public long Update(Point model)
        {
            using (var context = new OpenMuseumContext())
            {
                var originalPoint = context.Points.Include(a => a.DataLayers)
                    .SingleOrDefault(a => a.Id == model.Id);

                if (originalPoint != null)
                {
                    if (originalPoint.DataLayers != null && model.DataLayers != null)
                    {
                        var originalDataLayerIds = originalPoint.DataLayers.Select(x => x.Id).ToList();
                        var newDataLayerIds = model.DataLayers.Select(x => x.Id).ToList();
                        var dataLayersToAdd = context.DataLayers.Where(x => newDataLayerIds.Contains(x.Id)).Where(x => !originalDataLayerIds.Contains(x.Id)).ToList();

                        var tagsToRemove = originalPoint.DataLayers.Select(x =>
                        {
                            if (!newDataLayerIds.Contains(x.Id))
                            {
                                return x;
                            }

                            return null;
                        }).Where(x => x != null).ToList();

                        foreach (var dataLayer in tagsToRemove)
                        {
                            originalPoint.DataLayers.Remove(dataLayer);
                        }

                        foreach (var dataLayer in dataLayersToAdd)
                        {
                            originalPoint.DataLayers.Add(dataLayer);
                        }
                    }

                    if (originalPoint.DataLayers == null && model.DataLayers != null)
                    {
                        originalPoint.DataLayers = new List<DataLayer>();
                        foreach (var dataLayer in model.DataLayers)
                        {
                            context.Entry(dataLayer).State = EntityState.Modified;
                            originalPoint.DataLayers.Add(dataLayer);
                        }
                    }

                    if (originalPoint.DataLayers != null && model.DataLayers == null)
                    {
                        foreach (var dataLayer in originalPoint.DataLayers.ToList())
                        {
                            originalPoint.DataLayers.Remove(dataLayer);
                        }
                    }

                    context.SaveChanges();
                }

                originalPoint.Name = model.Name;
                originalPoint.Description = model.Description;
                originalPoint.RegionId = model.RegionId;
                originalPoint.Latitude = model.Latitude;
                originalPoint.Longitude = model.Longitude;
                originalPoint.PageId = model.PageId;

                context.Entry(originalPoint).State = EntityState.Modified;
                context.SaveChanges();

                return originalPoint.Id;
            }
        }

        public void Delete(long id)
        {
            using (var context = new OpenMuseumContext())
            {
                var model = context.Points.First(x => x.Id == id);
                context.Entry(model).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
