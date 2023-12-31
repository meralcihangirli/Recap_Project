﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        //iş katmanında kullanılan servis operasyonları
        IDataResult<List<User>> GetAll();
        IDataResult<List<User>> GetById(int userId);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
