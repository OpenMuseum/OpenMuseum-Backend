using System;
using System.Data.Entity;
using System.IO;
using System.IO.Compression;
using OpenMuseum.Models;

namespace OpenMuseum.Repositories
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<OpenMuseumContext>
    {
        protected override void Seed(OpenMuseumContext context)
        {

            var uniqId = Guid.NewGuid();
            var sourcePath = AppDomain.CurrentDomain.BaseDirectory + "App_Data/paris1590.zip";
            var destinationPath = AppDomain.CurrentDomain.BaseDirectory + "Public/";

            var extractPath = Path.Combine(destinationPath, uniqId.ToString());
            ZipFile.ExtractToDirectory(sourcePath, extractPath);

            var baseLayer = new BaseLayer
            {
                Id = 1,
                Name = "Modern Saratov",
                Description = "Modern saratov layer",
                UniqId = uniqId,
                Url = "http://sarkrepost.azurewebsites.net/Public/" + uniqId + "/{z}/{x}/{y}.png",
                Default = true,
                Height = 1000,
                Width = 2000
            };

            context.BaseLayers.Add(baseLayer);

            var dataLayer = new DataLayer
            {
                Id = 1,
                BaseLayerId = 1,
                Name = "Architecture",
                Description = "Architecture layer"
            };

            context.DataLayers.Add(dataLayer);

            var point = new Point
            {
                Id = 1,
                DataLayerId = 1,
                Name = "Eufel tower",
                Content = "<b>tower</b>",
                Latitude = 2400,
                Longitude = 3000
            };

            context.Points.Add(point);

            var region = new Region
            {
                Name = "Museum square",
                Description = "Museum square description",
                Content = "<b>tower</b>",
                Coordinates = "",
                BaseLayerId = 1
            };

            context.Regions.Add(region);

            context.SaveChanges();
        }
    }
}
