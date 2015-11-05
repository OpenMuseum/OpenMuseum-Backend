using OpenMuseum.Backend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMuseum.Repositories
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<OpenMuseumContext>
    {
        protected override void Seed(OpenMuseumContext context)
        {
            var baseLayer = new BaseLayer();
            baseLayer.Name = "Modern Saratov";
            baseLayer.Description = "Modern saratov layer";
            baseLayer.Url = "http://oldsaratov.ru";

            context.BaseLayers.Add(baseLayer);
            context.SaveChanges();
        }
    }
}
