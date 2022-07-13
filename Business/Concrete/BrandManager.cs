using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        [ValidationAspect(typeof(BrandValidator))]
        public IResult add(Brand brand)
        {
            IResult result = BusinessRules.Run(CheckIfBrandNameExist(brand.BrandName));
            if(result != null)
            {
                return result;
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>> (_brandDal.GetAll(),Messages.ItemListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            var result = _brandDal.Get(b => b.BrandId == id);
            if(result == null)
            {
                return new ErrorDataResult<Brand>(result,Messages.EmptyItem);
            }
            return new SuccessDataResult<Brand> (result);
        }

        public IResult update(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.ItemNameInvaild);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.ItemAdded);
        }
        private IResult CheckIfBrandNameExist(string brandName)
        {
            var result = _brandDal.GetAll(b => b.BrandName == brandName).Any();
            if (result)
            {
                return new ErrorResult(Messages.BrandNameAlreadyExits);
            }
            return new SuccessResult();
        }
    }
}
