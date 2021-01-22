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
    public class ArtistController:Controller
    {
        private BambooDbContext context;

        public ArtistController(BambooDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginArtistViewModel LoginArtistViewModel)
        {

            if (ModelState.IsValid)
            {
                var obj = context.Users.Where(a => a.EmailAddress.Equals(LoginArtistViewModel.EmailAddress) && a.Password.Equals(LoginArtistViewModel.Password)).FirstOrDefault();
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

        [HttpPost]
        public IActionResult Register(AddArtistViewModel addArtistViewModel)
        {
            if (ModelState.IsValid)
            {

                //if (context.Users.SingleOrDefault(a => a.Email == addUserViewModel.Email) == null)
                Artist newArtist = new Artist
                {
                    Username = addArtistViewModel.Username,
                    EmailAddress = addArtistViewModel.EmailAddress,
                    FirstName = addArtistViewModel.FirstName,
                    LastName = addArtistViewModel.LastName,
                    Password = addArtistViewModel.Password,
                };
                context.Artists.Add(newArtist);
                context.SaveChanges();

                //popup for successful Registration
                return Redirect("Login");
            }

            else
            {

                return Redirect("Home");
            }

        }

    }
}
