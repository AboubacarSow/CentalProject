using Cental.DataAccesLayer.Abstract;
using Cental.DataAccesLayer.Context;
using Cental.DataAccesLayer.Repositories;
using Cental.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccesLayer.Concret
{
    public class EfCarDal : GenericRepository<Car>, ICarDal
    {
        public EfCarDal(CentalDbContext context) : base(context)
        {
        }

        public List<Car> GetCarsWithBrand()
        {
            return _context.Cars.Include(c => c.Brand).ToList();
        }
    }
}
