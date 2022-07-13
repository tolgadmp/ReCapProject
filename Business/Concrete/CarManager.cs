using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckCarCountOfColorCorrect(car));
            if (result != null)
            {
                return result;
                    
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.ItemAdded);

        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.ItemListed);
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(c => c.CarId == id);
            if (result == null)
            {
                return new ErrorDataResult<Car>(result, Messages.EmptyItem);
            }
            return new SuccessDataResult<Car>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetCarDetails(),Messages.ItemListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),Messages.ItemListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id),Messages.ItemListed);
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.ItemUpdated);
        }

        private IResult CheckCarCountOfColorCorrect(Car car)
        {
            var result = _carDal.GetAll(c => c.ColorId == car.ColorId).Count;
            if(result >= 15)
            {
                return new ErrorResult(Messages.CarCountOfCategoryError);
            }
            return new SuccessResult();
        }
    }
}
