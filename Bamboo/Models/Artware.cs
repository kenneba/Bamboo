using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bamboo.Models
{
    public class Artware
    {
        public int ID { get; set; }
        public string Description { get; set; }
        [Required]

        public double Price { get; set; }
        [Required]

        public IFormFile ArtwareImage { get; set; }
    }
}
