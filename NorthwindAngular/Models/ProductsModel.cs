using NorthwindAngular.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindAngular.Models
{
    public class ProductsModel
    {
        public List<Products> plist { get; set; }
        public List<CategoriesDTO> clist { get; set; }
        public List<SupplierDTO> slist { get; set; }
        public Products product { get; set; }
        public int id { get; set; }//Silebilirsin
  

    }
}