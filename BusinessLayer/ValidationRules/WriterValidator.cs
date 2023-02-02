using System;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRule
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı boş geçilemez");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Email boş geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre boş geçilmez");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage(" Minimum 2 karakter yazabilirsiniz");
            RuleFor(x => x.WriterName).MaximumLength(30).WithMessage("Maksimum 50 karakter yazabilirsiniz");
            
            
        }
        
    }
}

