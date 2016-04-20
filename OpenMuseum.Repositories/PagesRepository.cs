using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenMuseum.Models;

namespace OpenMuseum.Repositories
{
    public class PagesRepository
    {
        public IEnumerable<Page> GetAll(out IDisposable context)
        {
            var db = new OpenMuseumContext();
            context = db;

            return db.Pages.Include(x => x.Tags);
        }

        public Page GetById(long id)
        {
            using (var context = new OpenMuseumContext())
            {
                var model = context.Pages.Include(x => x.Tags).First(x => x.Id == id);

                return model;
            }
        }

        public long Add(Page model)
        {
            using (var context = new OpenMuseumContext())
            {
                var pageResult = context.Pages.Add(model);
                context.Entry(pageResult).State = EntityState.Added;
                context.SaveChanges();

                return pageResult.Id;
            }
        }

        public long Update(Page model)
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
                var model = context.Pages.First(x => x.Id == id);
                context.Entry(model).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
