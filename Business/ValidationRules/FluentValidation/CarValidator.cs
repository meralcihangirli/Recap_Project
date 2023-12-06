using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{  //dtolar icin de bunu kullanabılırsın
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Description).MinimumLength(3).WithMessage("Aciklama min 3 harf icermelidir");
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(500).When(c => c.ModelYear == "2022");//modelyılı 2022 olanın günlük ücreti 500 ve üstü olmalıdır.
           RuleFor(c=>c.ModelYear).Must(StartWith).WithMessage("model yılı 2000 ve üzeri olmalıdır");
        }

        private bool StartWith(string arg)//arg aslında modelyear
        {
            return arg.StartsWith("2");
        }
    }

   
}