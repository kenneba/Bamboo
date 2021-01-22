using Bamboo.Data;
using Bamboo.Models;
using Bamboo.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bamboo.Controllers
{
    public class UserController: Controller
    {
        private BambooDbContext context;

        public UserController(BambooDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserViewModel LoginUserViewModel)
        {

            if (ModelState.IsValid)
            {
                var obj = context.Users.Where(a => a.EmailAddress.Equals(LoginUserViewModel.EmailAddress) && a.Password.Equals(LoginUserViewModel.Password)).FirstOrDefault();
                if (obj != null)
                {
                    HttpContext.Session.SetString("emailaddress", obj.EmailAddress);
                    HttpContext.Session.SetInt32("id", obj.ID);
                    HttpContext.Session.SetString("firstname", obj.FirstName);
                   
                    return Redirect("~/Home");
                }
                else
                {
                    return Redirect("Login");
                }
            }

            else
            {

                return Redirect("~/Home");
            }

        }

        public IActionResult Register()
        {
            return View();
        }


        //public IActionResult Register()
        //{
        //    AddUserViewModel addUserViewModel = new AddUserViewModel();
        //    return View(addUserViewModel);
        //}



        [HttpPost]
        public IActionResult Register(AddUserViewModel addUserViewModel)
        {
            if (ModelState.IsValid)
            {

                //if (context.Users.SingleOrDefault(a => a.Email == addUserViewModel.Email) == null)
                User newUser = new User
                {
                    EmailAddress = addUserViewModel.EmailAddress,
                    FirstName = addUserViewModel.FirstName,
                    LastName = addUserViewModel.LastName,
                    Password = addUserViewModel.Password,
                };
                context.Users.Add(newUser);
                context.SaveChanges();

                //popup for successful Registration
                return Redirect("Login");
            }

            else
            {
               
                return Redirect("Home");
            }
     
        } 

        //private void Login(User user)
        //{

        //}
    }
}
