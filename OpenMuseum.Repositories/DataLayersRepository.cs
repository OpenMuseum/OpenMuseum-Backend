using OpenMuseum.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMuseum.Repositories
{
    public class DataLayersRepository
    {
        public IEnumerable<DataLayer> GetAll()
        {
            var context = new OpenMuseumContext();

            return context.DataLayers.AsEnumerable();
        }
    }
}
