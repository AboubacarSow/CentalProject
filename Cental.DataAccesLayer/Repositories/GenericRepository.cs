using Cental.DataAccesLayer.Abstract;
using Cental.DataAccesLayer.Context;

namespace Cental.DataAccesLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        protected readonly CentalDbContext _context;

        public GenericRepository(CentalDbContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
           _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var value=GetById(id);
            _context.Remove(value); 
            _context.SaveChanges(true); 
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges(true); 
        }
    }
}
