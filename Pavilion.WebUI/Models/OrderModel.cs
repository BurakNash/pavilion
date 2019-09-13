using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pavilion.WebUI.Models
{
    public class OrderModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string Cvv { get; set; }
        public CartModel CartModel { get; set; }
    }
}
