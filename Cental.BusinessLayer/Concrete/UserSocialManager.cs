using Cental.BusinessLayer.Abstract;
using Cental.DataAccesLayer.Abstract;
using Cental.EntityLayer.Entities;

namespace Cental.BusinessLayer.Concrete
{
    public class UserSocialManager : GenericManager<MSocialMedia>, IUserSocialService
    {
        private readonly IUserSocialDal _userSocialDal;
        public UserSocialManager(IGenericDal<MSocialMedia> genericdal, IUserSocialDal userSocialDal) : base(genericdal)
        {
            _userSocialDal= userSocialDal;  
        }

        public List<MSocialMedia> GetByUserId(int id)
        {
            return _userSocialDal.TGetByUserId(id);
        }
    }
}
