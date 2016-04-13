using System;
using System.Data.Entity;
using System.IO;
using System.IO.Compression;
using OpenMuseum.Models;
using System.Collections.Generic;

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
                Name = "Современный Саратов",
                Description = "Отрисованная вручную современная карта Саратова",
                UniqId = uniqId,
                Url = "http://sarkrepost.azurewebsites.net/Public/" + uniqId + "/{z}/{x}/{y}.png",
                Default = true,
                Height = 1000,
                Width = 2000
            };

            context.BaseLayers.Add(baseLayer);

            var archLayer = new DataLayer
            {
                Id = 1,
                BaseLayerId = 1,
                Name = "Архитектура",
                Description = "Слой памятников архитектуры"
            };

            context.DataLayers.Add(archLayer);

            var religionLayer = new DataLayer
            {
                Id = 2,
                BaseLayerId = 1,
                Name = "Церкви",
                Description = "Слой религиозных объектов"
            };

            context.DataLayers.Add(religionLayer);

            var monumentLayer = new DataLayer
            {
                Id = 3,
                BaseLayerId = 1,
                Name = "Памятники",
                Description = "Слой памятников"
            };

            context.DataLayers.Add(monumentLayer);


            var leninLayer = new DataLayer
            {
                Id = 4,
                BaseLayerId = 1,
                Name = "Памятники Ленину",
                Description = "Слой памятников Ленину",
                ParentId = 3
            };

            context.DataLayers.Add(leninLayer);

            var regionPage = new Page
            {
                Id = 1,
                Name = "Страница: Музейная площадь",
                Content = "<b>Музейная площадь</b>"
            };

            context.Pages.Add(regionPage);

            var region = new Region
            {
                Name = "Музейная площадь",
                Description = "Самый старый квартал Саратова",
                Coordinates = "",
                BaseLayerId = 1,
                Page = regionPage
            };

            context.Regions.Add(region);

            var point = new Point
            {
                Id = 1,
                DataLayers = new List<DataLayer>() { archLayer, religionLayer },
                Name = "Троицкий собор",
                Description = "Старейшая церковь Саратова",
                Latitude = 2400,
                Longitude = 3000,
                Region = region
            };

            context.Points.Add(point);

            var tag1 = new Tag
            {
                Id = 1,
                Name = "Церкви",
            };

            context.Tags.Add(tag1);

            var tag2 = new Tag
            {
                Id = 2,
                Name = "Классицизм",
            };

            context.Tags.Add(tag2);

            var page = new Page
            {
                Id = 1,
                Tags = new List<Tag>() { tag1, tag2 },
                Name = "Страница: Троицкий собор",
                Content = "<b>Троицкий собор</b>",
                Point = point
            };

            context.Pages.Add(page);


            context.SaveChanges();
        }
    }
}
