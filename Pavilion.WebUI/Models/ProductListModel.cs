using Pavilion.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pavilion.WebUI.Models    
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string CurrentCategory { get; set; }
        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
            //returning int value with math.ceiling
        }
    }
    public class ProductListModel
    {
        public PagingInfo PagingInfo { get; set; }
        public List<Product> Products { get; set; }
        //public List<Category> Categories { get; set; }
    }
}
