using Microsoft.AspNetCore.Identity;

namespace HotelProject.WebUI.Models.CustomerIdentityValidator
{
    public class CustomerIdentityValidator : IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length) //Kayıt olma kısmında passwordde uygun şekilde giriş yapması için yapılan işlem
        {
            return new IdentityError()
            {
                Code = "PasswordTooShort",
                Description = $"Parola en az {length} olmalıdır."
            };
        }
        public override IdentityError PasswordRequiresUpper()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresUpper",
                Description = "En az 1 büyük harf giriniz.",
            };
        }
        public override IdentityError PasswordRequiresLower()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresLower",
                Description = "En az 1 küçük harf giriniz."
            };
        }
        public override IdentityError PasswordRequiresDigit()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresDigit",
                Description = "En az 1 rakam giriniz.",
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "En az 1 sembol giriniz {!,#,/,+}."
            };
        }
    }
}
