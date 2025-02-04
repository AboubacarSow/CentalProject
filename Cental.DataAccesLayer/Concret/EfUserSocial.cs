using Cental.DataAccesLayer.Abstract;
using Cental.DataAccesLayer.Context;
using Cental.DataAccesLayer.Repositories;
using Cental.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cental.DataAccesLayer.Concret
{
    public class EfUserSocial : GenericRepository<MSocialMedia>, IUserSocialDal
    {
        public EfUserSocial(CentalDbContext context) : base(context)
        {
        }

        public List<MSocialMedia> TGetByUserId(int id)
        {
            return _context.MSocialMedias.Where(s=>s.UserId == id).ToList();
        }
    }
}
