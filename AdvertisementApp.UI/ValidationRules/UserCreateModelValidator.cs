using AdvertisementApp.UI.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator : AbstractValidator<UserCreateModel>
    {
      //  [Obsolete]
        public UserCreateModelValidator()
        {
            //CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Password).NotEmpty().WithMessage("Parola boş olamaz");
            RuleFor(x => x.Password).MinimumLength(3).WithMessage("Parola en az 3 karakterli olmalıdır");
            RuleFor(x => x.Password).Equal(x=>x.ConfirmPassword).WithMessage("Parolalar uyuşmuyor");
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Ad boş olamaz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad boş olamaz");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(x => x.Username).MinimumLength(3).WithMessage("Kullanıcı min 3 karakter olmalıdır");
            RuleFor(x => new
            {
               x.Username,
               x.Firstname
            }).Must(x=> CanNotFirstName(x.Username,x.Firstname) ).WithMessage("kullanıcı adı adınızdan harf içermemeli!").When(x=>x.Username!=null&&x.Firstname!=null);
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet seçimi zorunludur");
           

        }

        private bool CanNotFirstName(string username, string firstname)
        {
            return !username.Contains(firstname);

        }
    }
}
