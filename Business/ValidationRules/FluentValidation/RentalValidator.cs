using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator(Car car)
        {
            RuleFor(r => r.ReturnDate).NotEmpty().When(r => r.CarId != car.Id);
            RuleFor(r=>r.CustomerId).NotEmpty();
         RuleFor(r=>r.RentDate).NotEmpty();
          
        }


    }
}
