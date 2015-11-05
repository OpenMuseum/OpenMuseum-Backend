using OpenMuseum.Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMuseum.Repositories
{
    public class PointsRepository
    {
        public IEnumerable<Point> GetAll()
        {
            var context = new OpenMuseumContext();

            return context.Points.AsEnumerable();
        }
    }
}
