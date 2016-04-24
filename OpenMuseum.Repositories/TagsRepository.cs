using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OpenMuseum.Models;

namespace OpenMuseum.Repositories
{
    public class TagsRepository
    {
        public IEnumerable<Tag> GetAll(out IDisposable context)
        {
            var db = new OpenMuseumContext();
            context = db;

            return db.Tags.Include(x => x.Pages);
        }

        public Tag GetById(long id)
        {
            using (var context = new OpenMuseumContext())
            {
                var model = context.Tags.Include(x => x.Pages).First(x => x.Id == id);

                return model;
            }
        }

        public long Add(Tag model)
        {
            using (var context = new OpenMuseumContext())
            {
                var result = context.Tags.Add(model);
                context.Entry(result).State = EntityState.Added;
                context.SaveChanges();

                return result.Id;
            }
        }

        public long Update(Tag model)
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
                var model = context.Tags.First(x => x.Id == id);
                context.Entry(model).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Tag> GetByStringIds(string[] selectedTags)
        {
            using (var context = new OpenMuseumContext())
            {
                return context.Tags.Where(x => selectedTags.Contains(x.Id.ToString())).ToList();
            }
        }
    }
}
