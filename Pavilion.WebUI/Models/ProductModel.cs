﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pavilion.WebUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        //public IFormFile ImageFile { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
