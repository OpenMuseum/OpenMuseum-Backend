using OpenMuseum.Backend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMuseum.Repositories
{
    public class DataInitializer : DropCreateDatabaseAlways<OpenMuseumContext>
    {
        protected override void Seed(OpenMuseumContext context)
        {
            var baseLayer = new BaseLayer();

            baseLayer.Id = 1;
            baseLayer.Name = "Modern Saratov";
            baseLayer.Description = "Modern saratov layer";
            baseLayer.Url = "http://sarkrepost.azurewebsites.net/Data/base.jpg";

            context.BaseLayers.Add(baseLayer);

            var dataLayer = new DataLayer();
            dataLayer.Id = 1;
            dataLayer.BaseLayerId = 1;
            dataLayer.Name = "Architecture";
            dataLayer.Description = "Architecture layer";

            context.DataLayers.Add(dataLayer);

            context.SaveChanges();
        }
    }
}
