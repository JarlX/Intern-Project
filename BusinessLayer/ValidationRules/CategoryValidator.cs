using System;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori İçeriğini Boş Geçemezsiniz");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori Adı Maksimum 50 karakter Olabilir");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Kategori Adın Minimum 2 Karakter Olabilir");

        }
       
    }
}

