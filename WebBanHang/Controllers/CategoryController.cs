using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
using WebBanHang.Context;
using PagedList;

namespace WebBanHang.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        [Route("tat-ca-danh-muc")]
        public ActionResult CategoryList()
        {
            WebBanHangASPEntities webBanHangASP = new WebBanHangASPEntities();
            CategoryModel objCategory = new CategoryModel();
            objCategory.ListCategory = webBanHangASP.Category_0242.ToList();
            return View(objCategory);
        }
        [Route("san-pham-danh-muc/{slug}/page-{pageNumber:int?}/{id:int?}")]
        public ActionResult CategoryProduct(int Id=0, int view=0,int pageNumber=1,int limit=5)
        {
            WebBanHangASPEntities webBanHangASP = new WebBanHangASPEntities();
            
            CategoryModel objCategory = new CategoryModel();
            objCategory.id = Id;
            ViewBag.CurrentCategoryId = Id;
            objCategory.view = view;
            //Lấy danh sách category
            objCategory.ListCategory = webBanHangASP.Category_0242.ToList();
            //Lấy danh sách thương hiệu
            objCategory.ListBrand = webBanHangASP.Brand_0242.ToList();
            //Lấy danh sách sản phẩm theo category
         
            if (Id == 0 )
            {
                objCategory.ListProductCategory = webBanHangASP.Product_0242.OrderByDescending(n=>n.Id).ToPagedList(pageNumber,limit);
            }
            else
            {
                objCategory.ListProductCategory = webBanHangASP.Product_0242.Where(n => n.CategoryId == Id).OrderByDescending(n=>n.Id).ToPagedList(pageNumber, limit);
            }
            return View(objCategory);
        }
    }
}