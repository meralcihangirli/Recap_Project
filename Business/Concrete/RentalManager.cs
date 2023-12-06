using Azure.Messaging;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
           
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            var result=_rentalDal.Get(r=>r.Id == rental.Id);
            if (result != null)
            {
                _rentalDal.Delete(result);
                return new SuccessResult(Messages.RentalDeleted);
            }
            return new ErrorResult(Messages.RentalInvalid);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetById(int rentalId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.Id == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> RentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.RentalDetails());
        }

        public IResult Update(Rental rental)
        {
            var result=_rentalDal.Get(r=>r.Id==rental.Id);
            if (result != null)
            {
                _rentalDal.Update(result);
                return new SuccessResult(Messages.RentalUpdated);
            }
            return new ErrorResult(Messages.RentalInvalid);
        }
    }
}
