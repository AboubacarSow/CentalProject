﻿using Cental.DataAccesLayer.Abstract;
using Cental.DataAccesLayer.Context;
using Cental.DataAccesLayer.Repositories;
using Cental.EntityLayer.Entities;

namespace Cental.DataAccesLayer.Concret
{
    public class EfBrandDal : GenericRepository<Brand>, IBrandDal
    {
        public EfBrandDal(CentalDbContext context) : base(context)
        {
        }
    }
}
