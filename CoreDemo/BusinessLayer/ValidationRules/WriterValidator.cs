using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı ve Soyadı Boş Geçilemez");
            RuleFor(x => x.WriterEmail).NotEmpty().WithMessage("E-Mail Adresi Boş Geçilemez");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez");
            RuleFor(x => x.WriterPassword).Must(IsPasswordValid).WithMessage("Parola en az 6 karakter olmalıdır.En az bir harf ve bir sayı içermelidir");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En Az 2 Karakter Giriniz");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En Fazla 50 Karakter Giriniz");
        }

        private bool IsPasswordValid(string arg)
        {
            try
            {
                Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,}$");
                return regex.IsMatch(arg);
            }
            catch
            {
                return false;
            }
        }
    }
}
