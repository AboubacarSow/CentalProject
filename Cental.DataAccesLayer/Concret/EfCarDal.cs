using Cental.DataAccesLayer.Abstract;
using Cental.DataAccesLayer.Context;
using Cental.DataAccesLayer.Repositories;
using Cental.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;


namespace Cental.DataAccesLayer.Concret
{
    public class EfCarDal : GenericRepository<Car>, ICarDal
    {
     
        public EfCarDal(CentalDbContext context) : base(context)
        {
        }

        public IQueryable<Car> GetById(int id, bool trackChanges)
        {
            return !trackChanges ?
                 _context.Cars.Where(x => x.CarId == id).AsNoTracking()
                : _context.Cars.Where(x => x.CarId == id);
        }

        public List<Car> GetCarsWithBrand()
        {
            return _context.Cars.Include(c => c.Brand).ToList();
        }
    }
}
