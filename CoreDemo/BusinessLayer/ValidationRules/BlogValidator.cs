using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogName).NotEmpty().WithMessage("BLog Adı Boş Bırakılamaz");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("BLog İçeriği Boş Bırakılamaz");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("BLog Görseli Boş Bırakılamaz");
            RuleFor(x => x.BlogName).MaximumLength(50).WithMessage("BLog Adı 50 Karakteri Geçemez");
            RuleFor(x => x.BlogName).MinimumLength(5).WithMessage("BLog Adı 5 Karakterden Fazla Olmalı");
        }
    }
}
