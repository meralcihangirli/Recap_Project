using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool //buraya ıvalidator verıosun o da ilgili metodun parametrelerini validate etmek istediğimiz fluentvalidation kurallarını uyguluyor
    {

        public static void Validate(IValidator validator,object entity) //vsalidor dogrulama kuralları, entity: dogrulanacak metot
        {
            var context=new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
            }
        }
    }
}
