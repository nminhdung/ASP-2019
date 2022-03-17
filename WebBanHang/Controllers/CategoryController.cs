using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult CategoryList()
        {
            WebBanHangASPEntities webBanHangASP = new WebBanHangASPEntities();
            CategoryModel objCategory = new CategoryModel();
            objCategory.ListCategory = webBanHangASP.Category_0242.ToList();
            return View(objCategory);
        }
        public ActionResult CategoryProduct(int Id, int view=0)
        {
            WebBanHangASPEntities webBanHangASP = new WebBanHangASPEntities();
            
            CategoryModel objCategory = new CategoryModel();
            objCategory.id = Id;
            objCategory.view = view;
            //Lấy danh sách category
            objCategory.ListCategory = webBanHangASP.Category_0242.ToList();
            //Lấy danh sách thương hiệu
            objCategory.ListBrand = webBanHangASP.Brand_0242.ToList();
            //Lấy danh sách sản phẩm theo category
            objCategory.ListProductCategory = webBanHangASP.Product_0242.Where(n => n.CategoryId == Id).ToList();
            return View(objCategory);
        }
    }
}