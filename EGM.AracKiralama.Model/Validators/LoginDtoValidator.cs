using EGM.AracKiralama.Model.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.EPosta).NotNull().NotEmpty().WithMessage("Eposta boş geçilemez.")
                .EmailAddress().WithMessage("Geçerli bir eposta giriniz.");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Şifre boş geçilemez")
                .Length(3, 15).WithMessage("Geçerli uzunlukta olmalıdır.");
        }
    }
}
