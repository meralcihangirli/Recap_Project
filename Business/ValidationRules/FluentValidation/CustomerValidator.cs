using Entities.Concrete;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator(User user)
        {
            RuleFor(cu => cu.CompanyName).NotEmpty();
            RuleFor(cu => user.FirstName).NotEmpty().When(cu => cu.Id == user.Id);

        }

    }
}
