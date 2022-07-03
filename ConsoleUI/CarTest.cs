using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class CarTest
    {
        CarManager carManager = new CarManager(new EfCarDal());
        public void GetCarDetails()
        {
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
        public static void ListCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarId + " / " + car.Description);
            }
        }

        public static void AddCar()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("Lütfen bir Araba ekleyiniz");
            Console.Write("Araba İsmi: ");
            string carName = Console.ReadLine();
            Console.Write("Araba Fiyati: ");
            decimal carPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Araba Model Yılı: ");
            int carYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Araba Açıklaması: ");
            string carDescription = Console.ReadLine();

            Car car1 = new Car();
            car1.BrandId = 1;
            car1.ColorId = 2;
            car1.DailyPrice = carPrice;
            car1.Description = carName;
            car1.ModelYear = carYear;
            car1.Description = carDescription;

            carManager.Add(car1);
        }

        public static void DeleteCar(int id)
        {
            try
            {
                CarManager carManager = new CarManager(new EfCarDal());
                var silinecekAraba = carManager.GetById(id);
                carManager.Delete(silinecekAraba.Data);
            }
            catch (Exception)
            {

                throw new Exception("Araba Silinemedi");
            }
        }

        /*public static void UpdateCar(int id)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var updateCar = carManager.GetById(id);

            Console.Write("Araba İsmi: ");
            string carName = Console.ReadLine();
            Console.Write("Araba Fiyati: ");
            decimal carPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Araba Model Yılı: ");
            int carYear = Convert.ToInt32(Console.ReadLine());
            Console.Write("Araba Açıklaması: ");
            string carDescription = Console.ReadLine();

            updateCar.BrandId = 2;
            updateCar.ColorId = 1;
            updateCar.DailyPrice = carPrice;
            updateCar.Description = carName;
            updateCar.ModelYear = carYear;
            updateCar.Description = carDescription;

            carManager.Update(updateCar.Data);

        }*/
    }
}
