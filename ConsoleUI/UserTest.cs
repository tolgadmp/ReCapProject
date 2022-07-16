using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUI
{
    public class UserTest
    {
        UserManager userManager = new UserManager(new EfUserDal());
        public void addUser()
        {
            User user = new User();
            user.FirstName = "Arda";
            user.LastName = "Dmp";
            user.Email = "arda@gmail.com";
            user.Password = "123";
            userManager.Add(user);
        }
    }
}
