﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            /*CarTest carTest = new CarTest();
            carTest.GetCarDetails();

            UserTest userTest = new UserTest();
            userTest.addUser();*/

            CustomerTest customerTest = new CustomerTest();
            customerTest.addCustomer();

            


        }
    }
}
