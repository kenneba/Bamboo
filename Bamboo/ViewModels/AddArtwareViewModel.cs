using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bamboo.ViewModels
{
    public class AddArtwareViewModel
    {
        public int ID { get; set; }

        public int ArtistID {get;set;}
        public string Description { get; set; }
        [Required]

        public double Price { get; set; }
        [Required]

        public string ArtwareImage { get; set; }

        public void OnGet()
        {
        }

        public void OnPost(IFormFile file)
        {
            ArtwareImage = file.FileName;
        }
    }
}
