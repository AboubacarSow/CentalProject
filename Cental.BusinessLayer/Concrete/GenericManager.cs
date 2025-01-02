using Cental.BusinessLayer.Abstract;
using Cental.DataAccesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _genericdal;

        public GenericManager(IGenericDal<T> genericdal)
        {
            _genericdal = genericdal;   
        }
        public void TCreate(T entity)
        {
            _genericdal.Create(entity);
        }

        public void TDelete(int id)
        {
            _genericdal.Delete(id);
        }

        public List<T> TGetAll()
        {
            return _genericdal.GetAll();    
        }

        public T TGetById(int id)
        {
            return _genericdal.GetById(id);
        }

        public void TUpdate(T entity)
        {
            _genericdal.Update(entity); 
        }
    }

}
