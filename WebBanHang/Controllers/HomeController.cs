using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class HomeController : Controller
    {
        WebBanHangASPEntities webBanHangASP = new WebBanHangASPEntities();
        public ActionResult Index()
        {
            HomeModel objHomeModel = new HomeModel();
            //Kết nối lấy danh mục
            objHomeModel.ListCategory = webBanHangASP.Category_0242.ToList() ;
            //Kết nối lấy Sản phẩm deal
            objHomeModel.ListProductDeal = webBanHangASP.Product_0242.Where(n => n.TypeId == 1).ToList();
            //Lấy sản phẩm theo brand
            objHomeModel.ListProductBrand = webBanHangASP.Product_0242.Where(n => n.BrandId == 1).ToList();
            //Lấy sản phẩm đề xuất
            objHomeModel.ListProductRecommend = webBanHangASP.Product_0242.Where(n => n.TypeId == 2).ToList();
            //Kết nối lấy Sản phẩm hot
            objHomeModel.ListProductHot = webBanHangASP.Product_0242.Where(n => n.TypeId == 3).ToList();
            return View(objHomeModel);
        }
    }
}