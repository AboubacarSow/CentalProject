using Microsoft.AspNetCore.Identity;

namespace Cental.BusinessLayer.Validators.ErrorDescriber
{
    public class CustumErrorDescriber : IdentityErrorDescriber
	{
		public override IdentityError PasswordRequiresLower()
		{
			return new IdentityError
			{
				Description = "Şifre en az bir küçük (a-z) harf içermelidir."
			};
		}
		public override IdentityError PasswordRequiresUpper()
		{
			return new IdentityError
			{
				Description = "Şifre en az bir büyük (A-Z) harf içermelidir. "
			};
		}
		public override IdentityError PasswordRequiresDigit()
		{
			return new IdentityError
			{
				Description = "Şifre en az bir rakam (0-9)  içermelidir."
			};
		}
		public override IdentityError PasswordRequiresNonAlphanumeric()
		{
			return new IdentityError
			{
				Description = "Şifre en az bir öxel karakter (*,+,!, ...)  içermelidir."
			};
		}
		public override IdentityError PasswordTooShort(int length)
		{
			return new IdentityError
			{
				Description = $"Şifre en az {length} karakterden oluşmalıdır"
			};
		}
		public override IdentityError DuplicateEmail(string email)
		{
			return new IdentityError
			{
				Description = $"Daha önce bu {email} adresi sisteme kayıt olumuş."
			};
		}
		public override IdentityError DuplicateUserName(string userName)
		{
			return new IdentityError
			{
				Description = $"Daha önce bu {userName} kullanıcı sisteme kayıt olmuş"
			};
		}

	}
}
