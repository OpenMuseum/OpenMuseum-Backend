using OpenMuseum.Backend.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.IO.Compression;
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

            var uniqId = Guid.NewGuid();
            var sourcePath = AppDomain.CurrentDomain.BaseDirectory + "App_Data/paris1590.zip";
            var destinationPath = AppDomain.CurrentDomain.BaseDirectory + "Public/";

            var extractPath = Path.Combine(destinationPath, uniqId.ToString());
            ZipFile.ExtractToDirectory(sourcePath, extractPath);

            baseLayer.Id = 1;
            baseLayer.Name = "Modern Saratov";
            baseLayer.Description = "Modern saratov layer";
            baseLayer.UniqId = uniqId;
            baseLayer.Url = "http://sarkrepost.azurewebsites.net/Public/" + uniqId  + "/{z}/{x}/{y}.png";
            baseLayer.Default = true;
            baseLayer.Height = 1000;
            baseLayer.Width = 2000;

            context.BaseLayers.Add(baseLayer);

            var dataLayer = new DataLayer();
            dataLayer.Id = 1;
            dataLayer.BaseLayerId = 1;
            dataLayer.Name = "Architecture";
            dataLayer.Description = "Architecture layer";

            context.DataLayers.Add(dataLayer);

            var point = new Point();
            point.Id = 1;
            point.DataLayerId = 1;
            point.Name = "Eufel tower";
            point.Content = "<b>tower</b>";
            point.Latitude = 2400;
            point.Longitude = 3000;

            context.Points.Add(point);

            context.SaveChanges();
        }
    }
}
