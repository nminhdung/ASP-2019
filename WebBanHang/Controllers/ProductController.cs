using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Detail()
        {
            return View();
        }
        public ActionResult ProductListGrid()
        {
            return View();
        }
        public ActionResult ProductListLarge()
        {
            return View();
        }
    }
}