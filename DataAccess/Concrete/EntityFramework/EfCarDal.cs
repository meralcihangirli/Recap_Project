using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RecapProjectContext>, ICarDal
    {
        
        public List<CarDetailDto> GetCarDetails()
        {
            using (RecapProjectContext context = new RecapProjectContext())
            {
                var result = from c in context.Car
                             join b in context.Brand
                             on c.BrandId equals b.BrandId
                             join co in context.Color
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto {Id=c.Id, Description = c.Description, ColorName = co.ColorName, DailyPrice = c.DailyPrice };
                return result.ToList();
            }
        }

    }
}
