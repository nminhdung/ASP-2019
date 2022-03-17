using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class BrandModel
    {
        public int id { get; set; }
        public int view { get; set; }

        public List<Brand_0242> ListBrand { get; set; }
        public List<Product_0242> ListProductBrand { get; set; }
        public List<Category_0242> ListCategory { get; set; }
    }
}