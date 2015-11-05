using OpenMuseum.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMuseum.Repositories
{
    public class BaseLayersRepository
    {
        public IEnumerable<BaseLayer> GetAll()
        {
            var context = new OpenMuseumContext();

            return context.BaseLayers.AsEnumerable();
        }
    }
}
