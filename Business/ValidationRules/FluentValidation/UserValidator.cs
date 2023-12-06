using Core.Aspects.Autofac.Validation;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Password).Must(PasswordRules).WithMessage("şifre 6 haneli olmalı");

        }

        private bool PasswordRules(string arg)
        {
          
            return arg.Length == 6;

            //bool hasUpperCase = false;
            //bool hasLowerCase = false;

            //foreach (char c in arg)
            //{
            //    if (char.IsUpper(c))
            //    {
            //        hasUpperCase = true;
            //    }
            //    else if (char.IsLower(c))
            //    {
            //        hasLowerCase = true;
            //    }


            //    if (hasUpperCase && hasLowerCase)
            //    {
            //        break;
            //    }
            //}
        }
    }
}

