using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{//data simulasynu yapılan yer burası
 //veri varmıs gibi yapılan kısım
    //public class InMemoryCarDal : ICarDal
    //{//asagidaki list acıklamasi:bütün metodların dısında ama classın içinde tanımlanır bu tür tanımlanan degıskenlere global degısken denır ve _ile baslar
    //    //naming comention isilendirme standardı bu sekilde
    //    //constructor :bellekte referans aldıgı zaman olusacak(calısacak) olan bloktur

    //    List<Car> _cars;
    //    public InMemoryCarDal()
    //    {
    //        _cars = new List<Car> {
    //        new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=200,ModelYear="2020",Description="Kia"},
    //        new Car{Id=2,BrandId=1,ColorId=3,DailyPrice=250,ModelYear="2020",Description="Fiat"},
    //        new Car{Id=3,BrandId=2,ColorId=2,DailyPrice=350,ModelYear="2021",Description="Citroen"},
    //        new Car{Id=4,BrandId=2,ColorId=1,DailyPrice=400,ModelYear="2023",Description="Seat"},
    //        new Car{Id=5,BrandId=3,ColorId=3,DailyPrice=220,ModelYear="2022",Description="Volkswagen"},
    //        new Car{Id=6,BrandId=1,ColorId=1,DailyPrice=640,ModelYear="2023",Description="BMW"},
    //        };

    //    }
    //    //add kısmında parantez içindeki car businesstan gnderılen car
    //    public void Add(Car car)
    //    {
    //        _cars.Add(car);
    //    }

    //    public void Delete(Car car)
    //    {
    //        Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
    //        _cars.Remove(carToDelete);
    //    }

    //    public List<Car> GetAll()
    //    {
    //        return _cars;
    //    }

    //    public List<Car> GetByIdModelYear(string modelYear)
    //    {
    //        return _cars.Where(c => c.ModelYear == modelYear).ToList();
    //    }

    //    public void Update(Car car)
    //    {//gönderdigim ürün ıdsine sahip olan listedeki ürünü bul
    //        Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
    //        carToUpdate.ModelYear = car.ModelYear;
    //        carToUpdate.Description = car.Description;
    //        carToUpdate.BrandId = car.BrandId;
    //        carToUpdate.ColorId = car.ColorId;
    //        carToUpdate.DailyPrice = car.DailyPrice;

    //    }
    //}
}
