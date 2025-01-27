using Cental.BusinessLayer.Abstract;
using Cental.DataAccesLayer.Abstract;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.BusinessLayer.Concrete
{
	public class BrandManager : IBrandService
	{
		private readonly IBrandDal _brand;

		public BrandManager(IBrandDal brand)
		{
			_brand = brand;
		}

		public void TCreate(Brand entity)
		{
			_brand.Create(entity);
		}

		public void TDelete(int id)
		{
			_brand.Delete(id);
		}

		public List<Brand> TGetAll()
		{
			return _brand.GetAll();	
		}

		public Brand TGetById(int id)
		{
			return _brand.GetById(id);
		}

		public void TUpdate(Brand entity)
		{
			_brand.Update(entity);
		}
	}
}
