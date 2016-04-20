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
                context.Entry(model).State = EntityState.Modified;
                context.SaveChanges();

                return model.Id;
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
