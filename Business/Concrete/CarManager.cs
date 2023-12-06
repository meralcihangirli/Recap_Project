using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {//ne inmemory ne entiyframework ismi gececek


        //iş kodları varsa bunları yaz
        //InMemoryCarDal ınMemoryCarDal = new InMemoryCarDal();  
        //üstteki sekilde yazarsan yarın öbur gun yenı ekleme degısıklık noktasında bu alanı tek tek degıstırmen gerekebılır
        //bir iş sınıfı baska sınıfları newlemez asla



        ICarDal _carDal;
       IBrandService _brandService;
        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        //[ValidationAspect(typeof(CarValidator))] //add methoddunu dogrula CarValidator kurallaerına göre
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCarCountOfColorCorrect(car.ColorId),
              CheckIfCarSameName(car.Description), CheckIfBrandLimitExceded());
            if (result != null)
            {
                return result;
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);

        }

        public IResult Delete(Car car)
        {
            //_carDal.GetAll(c => c.Id == car.Id).ToList();
            //_carDal.Get(c => c.Id == car.Id);
            // _carDal.Delete();
            var result = _carDal.Get(c => c.Id == car.Id);
            if (result.Id == car.Id)
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.CarDeleted);
            }
            return new ErrorResult(Messages.CarNameInvalid);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetById(int carId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.Id == carId), Messages.CarListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {

            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarDetails);

        }

        public IResult Update(Car car)
        {
            if (CheckIfCarCountOfColorCorrect(car.ColorId).Success)
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.CarUpdated);
            }
            return new ErrorResult();
        }

        private IResult CheckIfCarCountOfColorCorrect(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId).Count;
            if (result >= 10)
            {
                return new ErrorResult("ürün rengi 10u aşmıştır ");
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarSameName(string description)
        {
            var result = _carDal.GetAll(c => c.Description == description).Any();
            if (result)
            {
                return new ErrorResult("ürün adı daha önce eklenmiştir ");
            }
            return new SuccessResult();
        }

        private IResult CheckIfBrandLimitExceded()
        {
            var result = _brandService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult("Marka adedi 15ten fazla olamaz");
            }
            return new SuccessResult();
        }

    }
}
