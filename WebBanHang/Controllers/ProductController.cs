using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;

namespace WebBanHang.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        [Route("san-pham/chi-tiet-san-pham/{slug}/{id}")]
        public ActionResult Detail(int Id,string slug)
        {
            WebBanHangASPEntities webBanHangASP = new WebBanHangASPEntities();
            //Lấy chi tiết sản phẩm
            var objProduct = webBanHangASP.Product_0242.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
       
    }
}