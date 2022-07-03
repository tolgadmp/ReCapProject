using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
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
        public IResult add(Brand brand)
        {

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
            return new SuccessDataResult<Brand> (_brandDal.Get(c => c.BrandId == id));
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
    }
}
