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
                Name = "Region: Музейная площадь",
                Content = "<b>Музейная площадь</b>"
            };

            context.Pages.Add(regionPage);

            var region = new Region
            {
                Id = 1,
                Name = "Музейная площадь",
                Description = "Самый старый квартал Саратова",
                Coordinates = @"{""type"":""Feature"",""properties"":{ },""geometry"":{ ""type"":""Polygon"",""coordinates"":[[[-29.089050292968746,50.17689812200105],[-19.94842529296875,53.4357192066942],[-16.96014404296875,58.53959476664049],[-15.37811279296875,63.470144746565445],[-13.44451904296875,67.2720426739952],[-13.26873779296875,69.53451763078358],[-15.905456542968748,71.52490903732816],[-15.905456542968748,72.23551372557404],[-17.66326904296875,73.52839948765174],[-19.06951904296875,72.65958846878621],[-20.82733154296875,72.23551372557404],[-22.23358154296875,71.52490903732816],[-24.51873779296875,71.52490903732816],[-30.14373779296875,70.37785394109227],[-31.549987792968754,68.5924865825295],[-32.95623779296875,64.99793920061401],[-34.88983154296875,60.15244221438077],[-34.71405029296875,56.65622649350222],[-32.25311279296875,52.26815737376817],[-29.089050292968746,50.17689812200105]]]}}",
                BaseLayer = baseLayer,
                Page = regionPage
            };

            context.Regions.Add(region);

            #region Tags
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
            #endregion

            var pointPage = new Page
            {
                Id = 2,
                Tags = new List<Tag>() { tag1, tag2 },
                Name = "Страница: Троицкий собор",
                Content = "<b>Троицкий собор</b>"
            };

            context.Pages.Add(pointPage);

            var point = new Point
            {
                Id = 1,
                DataLayers = new List<DataLayer>() { archLayer, religionLayer },
                Name = "Троицкий собор",
                Description = "Старейшая церковь Саратова",
                Coordinates = @"{""type"":""Feature"",""properties"":{},""geometry"":{""type"":""Point"",""coordinates"":[-28.417510986328125,54.470037612805754]}}",
                Region = region,
                Page = pointPage
            };

            context.Points.Add(point);

            context.SaveChanges();
        }
    }
}
