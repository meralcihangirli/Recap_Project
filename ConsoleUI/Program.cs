using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

public class Program
{
    private static void Main(string[] args)
    {
        CarManager carManager = new CarManager(new EfCarDal(),new BrandManager(new EfBrandDal()));
        UserManager userManager = new UserManager(new EfUserDal());
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        RentalManager rentalManager = new RentalManager(new EfRentalDal());
        BrandManager brandManager=new BrandManager(new EfBrandDal());
        ColorManager colorManager=new ColorManager(new EfColorDal());


    }
}
