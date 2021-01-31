using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1,BrandId=2,ColorId=1,ModelYear=1998,DailyPrice=38500,Description="Tüm ağır bakımları yapılmıştır"},
                new Car{Id=2,BrandId=1,ColorId=3,ModelYear=2021,DailyPrice=175000,Description="Dosta Gider."},
                new Car{Id=3,BrandId=4,ColorId=5,ModelYear=2017,DailyPrice=150000,Description="Doktor komşusundan tertemiz."},
                new Car{Id=4,BrandId=3,ColorId=4,ModelYear=2015,DailyPrice=220000,Description="Gel beğenmezsen yol paran benden"},
                new Car{Id=5,BrandId=5,ColorId=3,ModelYear=2020,DailyPrice=300000,Description="Hatasız Boyasız 0 ayarında"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int BrandId)
        {
            return _cars.Where(c => c.BrandId == BrandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}

