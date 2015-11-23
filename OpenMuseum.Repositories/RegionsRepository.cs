using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenMuseum.Models;

namespace OpenMuseum.Repositories
{
    public class RegionsRepository
    {
        public IEnumerable<Region> GetAll(out IDisposable context)
        {
            var db = new OpenMuseumContext();
            context = db;

            return db.Regions.Include(x => x.BaseLayer);
        }

        public Region GetById(long id)
        {
            using (var context = new OpenMuseumContext())
            {
                var model = context.Regions.Include(x => x.BaseLayer).First(x => x.Id == id);

                return model;
            }
        }

        public long Add(Region model)
        {
            using (var context = new OpenMuseumContext())
            {
                var result = context.Regions.Add(model);
                context.Entry(result).State = EntityState.Added;
                context.SaveChanges();

                return result.Id;
            }
        }

        public long Update(Region model)
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
                var model = context.Regions.First(x => x.Id == id);
                context.Entry(model).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
