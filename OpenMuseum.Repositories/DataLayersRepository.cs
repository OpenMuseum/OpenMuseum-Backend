using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenMuseum.Models;

namespace OpenMuseum.Repositories
{
    public class DataLayersRepository
    {
        public IEnumerable<DataLayer> GetAll(out IDisposable context)
        {
            var db = new OpenMuseumContext();
            context = db;

            return db.DataLayers.Include(x => x.BaseLayer).Include(x => x.Points).Include(x => x.Children);
        }

        public DataLayer GetById(long id)
        {
            var context = new OpenMuseumContext();
            var model = context.DataLayers.Include(x => x.BaseLayer).Include(x => x.Points).Include(x => x.Children).Include(x => x.Children.Select(y => y.Points)).First(x => x.Id == id);

            return model;
        }

        public long Add(DataLayer model)
        {
            using (var context = new OpenMuseumContext())
            {
                var result = context.DataLayers.Add(model);
                context.Entry(result).State = EntityState.Added;
                context.SaveChanges();

                return result.Id;
            }
        }

        public long Update(DataLayer model)
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
                var model = context.DataLayers.First(x => x.Id == id);
                context.Entry(model).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
