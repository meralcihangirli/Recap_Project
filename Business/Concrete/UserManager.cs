using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            var result = _userDal.Get(u => u.Id == user.Id);
            if (result.Id == user.Id)
            {
                _userDal.Delete(user);
                return new SuccessResult(Messages.CarDeleted);
            }
            return new ErrorResult(Messages.CarNameInvalid);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.UserListed);
        }

        public IDataResult<List<User>> GetById(int userId)
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(u => u.Id == userId),Messages.UserListed);
        }

        public IResult Update(User user)
        {
            var result = _userDal.Get(u => u.Id == user.Id);
            if (result.Id == user.Id)
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.CarDeleted);
            }
            return new ErrorResult(Messages.CarNameInvalid);
        }
    }
}
