using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHang.Context;

namespace WebBanHang.Models
{
    public class CategoryModel
    {
        public int id { get; set; }
        public int view { get; set; }
        public List<Category_0242> ListCategory { get; set; }
        public List<Brand_0242> ListBrand { get; set; }
        public IPagedList<Product_0242> ListProductCategory { get; set; }
    }
}