using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class CustomerTest
    {
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        public void addCustomer()
        {
            Customer customer1 = new Customer();
            customer1.UserId = 1;
            customer1.CompanyName = "DMPRentACar";
            customerManager.Add(customer1);
            Customer customer2 = new Customer();
            customer2.CompanyName = "BizimAraçKiralama";
            customer2.UserId = 3;
            customerManager.Add(customer2);
        }

    }
}
