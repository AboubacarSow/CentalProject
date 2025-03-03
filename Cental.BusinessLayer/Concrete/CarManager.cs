using Cental.BusinessLayer.Abstract;
using Cental.DataAccesLayer.Abstract;
using Cental.EntityLayer.Entities;

namespace Cental.BusinessLayer.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public void TCreate(Car entity)
        {
            _carDal.Create(entity);
        }
        public void TDelete(int id)
        {
            _carDal.Delete(id);
        }
        public List<Car> TGetCarsWithBrand()
        {
            return _carDal.GetCarsWithBrand();    
        }
        public Car TGetById(int id)
        {
            return _carDal.GetById(id);
        }
        public void TUpdate(Car entity)
        {
            _carDal.Update(entity);
        }
        public List<Car> TGetAll()
        {
            return _carDal.GetAll();
        }

        public Car? TGetCarById(int id, bool trackChanges)
        {
            return _carDal.GetById(id, trackChanges)
                           .SingleOrDefault();
        }
    }
}
