using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklamasını Boş Geçemezsiniz");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Kategori Adını En Az 2 Karakter Olmalıdır");
            RuleFor(x => x.CategoryName).MaximumLength(30).WithMessage("Kategori Adını En Fazla 30 Karakter Olmalıdır");
        }
    }
}
