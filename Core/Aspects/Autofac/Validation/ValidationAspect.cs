using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{//burası bir attribute:)
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {//depensive coding 
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("bu bir dogrulama sınıfı degil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//carvalidator instence olusturur.burası bır reflectıon kod
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//carvalidatorun calısma tıpını bul;generic tipi car gibi gibi.burası bır reflectıon kod
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);// car metot parametrelerini bul.invocation: metot demek.burası bır reflectıon kod
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
