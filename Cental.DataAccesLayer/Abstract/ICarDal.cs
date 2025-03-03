using Cental.EntityLayer.Entities;


namespace Cental.DataAccesLayer.Abstract
{
    public interface ICarDal : IGenericDal<Car>
    {
        List<Car> GetCarsWithBrand();
        IQueryable<Car> GetById(int id, bool trackChanges);
    }
}
