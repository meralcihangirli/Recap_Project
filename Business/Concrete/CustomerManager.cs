using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
             _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
           var result=_customerDal.Get(c=>c.Id==customer.Id);
            if (result != null)
            {
                _customerDal.Delete(result);
                return new SuccessResult(Messages.CustomerDeleted);
            }
            return new ErrorResult(Messages.CustomerInvalid);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll()); 
        }

        public IDataResult<List<Customer>> GetById(int customerId)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c=>c.Id==customerId),Messages.CustomerListed);
        }

        public IResult Update(Customer customer)
        {
            var result =_customerDal.Get(c=>c.Id==customer.Id);
            if (result !=null)
            {
                _customerDal.Update(customer);
                return new SuccessResult(Messages.CustomerUpdated);
            }
            return new ErrorResult(Messages.CustomerInvalid);
        }
    }
}
