using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using OpenMuseum_Backend.Models;

namespace OpenMuseum_Backend.Controllers
{
    public class LayersController : ApiController
    {
        // GET: api/Layers
        public HttpResponseMessage Get()
        {
            var result = new List<Layer>();

            var paris1550 = new Layer()
            {
                Id = 1,
                Name = "Paris 1550",
                Height = 6108,
                Width = 4444,
                TileUrl = "https://dl.dropboxusercontent.com/u/4605143/paris1550/{z}/{x}/{y}.png"
            };

            var paris1575 = new Layer()
            {
                Id = 2,
                Name = "Paris 1575",
                Height = 6108,
                Width = 4444,
                TileUrl = "https://dl.dropboxusercontent.com/u/4605143/paris1575/{z}/{x}/{y}.png"
            };

            result.Add(paris1575);
            result.Add(paris1550);

            var answer = JsonConvert.SerializeObject(result);
            return new HttpResponseMessage()
            {
                Content = new StringContent(answer, System.Text.Encoding.UTF8, "application/json")
            };
        }

        // GET: api/Layers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Layers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Layers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Layers/5
        public void Delete(int id)
        {
        }
    }
}
