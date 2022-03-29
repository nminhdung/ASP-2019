using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Context;

namespace WebBanHang.Models
{
    public class HomeModel
    {
        public List<Category_0242>ListCategory { get; set; }
        public List<Product_0242> ListProductDeal { get; set; }
        public List<Product_0242> ListProductBrand { get; set; }
        public List<Product_0242> ListProductRecommend { get; set; }
        public List<Product_0242> ListProductHot { get; set; }
    }
}