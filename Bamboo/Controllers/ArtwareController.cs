using Bamboo.Data;
using Bamboo.Models;
using Bamboo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bamboo.Controllers
{
    public class ArtwareController: Controller
    {
        private BambooDbContext context;

        public ArtwareController(BambooDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Add(AddArtwareViewModel addArtwareViewModel)
        {
            if (ModelState.IsValid)
            {

                //if (context.Users.SingleOrDefault(a => a.Email == addUserViewModel.Email) == null)
                Artware newArtware = new Artware
                {
                    Description = addArtwareViewModel.Description,
                    Price = addArtwareViewModel.Price,
                    ArtwareImage = addArtwareViewModel.ArtwareImage,
                    //ArtistID = addArtwareViewModel.ArtistID,
                };
                context.Artwares.Add(newArtware);
                context.SaveChanges();

                
                return Redirect("~/Home");
            }

            else
            {

                return Redirect("Home");
            }
            
        }
    }
}
