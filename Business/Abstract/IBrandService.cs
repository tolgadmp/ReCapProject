using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        void add(Brand brand);
        void delete(Brand brand);
        void update(Brand brand);
        List<Brand> GetAll();
        Brand GetById(int id);
    }
}
