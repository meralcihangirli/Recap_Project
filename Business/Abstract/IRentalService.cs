using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        //iş katmanında kullanılan servis operasyonları
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetById(int rentalId);
        IDataResult<List<RentalDetailDto>> RentalDetails();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
