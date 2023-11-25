using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class CreateGuestValidator : AbstractValidator<CreateGuestDto>
    {
        //ctor diyip bu sınıf açılır.
        public CreateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez.");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş geçilemez.");      
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Minimum sadece 2 karakter olabilir.");//Ad için kural
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Maximum sadece 20 karakter olabilir.");         
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Minimum sadece 2 karakter olabilir.");//Soyisim için kural
            RuleFor(x => x.Surname).MaximumLength(20).WithMessage("Maximum sadece 20 karakter olabilir.");      
            RuleFor(x => x.City).MinimumLength(2).WithMessage("Minimum sadece 2 karakter olabilir.");//Şehir için kural
            RuleFor(x => x.City).MaximumLength(20).WithMessage("Maximum sadece 20 karakter olabilir.");
        }
    }
}
