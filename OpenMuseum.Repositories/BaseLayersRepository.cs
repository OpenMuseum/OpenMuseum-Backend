﻿using OpenMuseum.Backend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenMuseum.Models;

namespace OpenMuseum.Repositories
{
    public class BaseLayersRepository
    {
        public IEnumerable<BaseLayer> GetAll(out IDisposable context)
        {
            var db = new OpenMuseumContext();
            context = db;
 
            return db.BaseLayers.Include(x => x.DataLayers).Include(x => x.Regions);
        }

        public BaseLayer GetById(long id)
        {
            var context = new OpenMuseumContext();
            var model = context.BaseLayers.Include(x => x.DataLayers).Include(x => x.Regions).First(x => x.Id == id);

            return model;
        }

        public long Add(BaseLayer model)
        {
            using (var context = new OpenMuseumContext())
            {
                var result = context.BaseLayers.Add(model);
                context.Entry(result).State = EntityState.Added;
                context.SaveChanges();

                return result.Id;
            }
        }

        public long Update(BaseLayer model)
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
                var model = context.BaseLayers.First(x => x.Id == id);
                context.Entry(model).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
