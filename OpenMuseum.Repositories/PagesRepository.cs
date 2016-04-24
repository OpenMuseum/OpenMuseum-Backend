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
                if (model.Tags != null)
                {
                    var tags = model.Tags.ToList();
                    model.Tags = new List<Tag>();

                    foreach (var tag in tags)
                    {
                        context.Tags.Attach(tag);
                        model.Tags.Add(tag);
                    }
                }

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
                var originalPage = context.Pages.Include(a => a.Tags)
                    .SingleOrDefault(a => a.Id == model.Id);

                if (originalPage != null)
                {
                    if (originalPage.Tags != null && model.Tags != null)
                    {
                        var originalTagIds = originalPage.Tags.Select(x => x.Id).ToList();
                        var newTagIds = model.Tags.Select(x => x.Id).ToList();
                        var tagsToAdd = context.Tags.Where(x => newTagIds.Contains(x.Id)).Where(x => !originalTagIds.Contains(x.Id)).ToList();

                        var tagsToRemove = originalPage.Tags.Select(x =>
                        {
                            if (!newTagIds.Contains(x.Id))
                            {
                                return x;
                            }

                            return null;
                        }).Where(x => x != null).ToList();

                        foreach (var tag in tagsToRemove)
                        {
                            originalPage.Tags.Remove(tag);
                        }

                        foreach (var tag in tagsToAdd)
                        {
                            originalPage.Tags.Add(tag);
                        }
                    }

                    if (originalPage.Tags == null && model.Tags != null)
                    {
                        originalPage.Tags = new List<Tag>();
                        foreach (var tag in model.Tags)
                        {
                            context.Entry(tag).State = EntityState.Modified;
                            originalPage.Tags.Add(tag);
                        }
                    }

                    if (originalPage.Tags != null && model.Tags == null)
                    {
                        foreach (var tag in originalPage.Tags.ToList())
                        {
                            originalPage.Tags.Remove(tag);
                        }
                    }

                    context.SaveChanges();
                }

                originalPage.Name = model.Name;
                originalPage.Description = model.Description;
                originalPage.Content = model.Content;
                originalPage.ExternalId = model.ExternalId;

                context.Entry(originalPage).State = EntityState.Modified;
                context.SaveChanges();

                return originalPage.Id;
            }
        }

        public void Delete(long id)
        {
            using (var context = new OpenMuseumContext())
            {
                var model = context.Pages.Include(x => x.Tags).First(x => x.Id == id);
                var tags = model.Tags.ToList();

                if (model.Tags != null)
                {
                    foreach (var tag in tags)
                    {
                        model.Tags.Remove(tag);
                    }
                }


                var pointsWithPage = context.Points.Where(x => x.PageId == id);
                if (pointsWithPage != null)
                {
                    foreach (var point in pointsWithPage)
                    {
                        point.PageId = null;
                        context.Entry(point).State = EntityState.Modified;
                    }
                }

                var regionsWithPage = context.Regions.Where(x => x.PageId == id);
                if (regionsWithPage != null)
                {
                    foreach (var region in regionsWithPage)
                    {
                        region.PageId = null;
                        context.Entry(region).State = EntityState.Modified;
                    }
                }

                context.Entry(model).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
