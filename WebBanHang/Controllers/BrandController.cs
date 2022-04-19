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
    public class BrandController : Controller
    {
        //
        // GET: /Brand/

        WebBanHangASPEntities webBanHangASP = new WebBanHangASPEntities();
        [Route("tat-ca-thuong-hieu")]
        public ActionResult ListBrand()
        {
            BrandModel objBrand = new BrandModel();
            objBrand.ListBrand = webBanHangASP.Brand_0242.ToList();
            return View(objBrand);
        }
        //[Route("san-pham-thuong-hieu/{slug}/page-{pageNumber:int?}/{id:int?}")]
        public ActionResult ProductBrand(int Id = 0, int view = 0, int pageNumber = 1, int limit = 5)
        {
            BrandModel objBrand = new BrandModel();
            objBrand.view = view;
            objBrand.id = Id;
            //Lấy danh sách loại sản phẩm
            objBrand.ListCategory = webBanHangASP.Category_0242.ToList();
            //Lấy danh sách thương hiệu
            objBrand.ListBrand = webBanHangASP.Brand_0242.ToList();
            //Lấy danh sách sản phẩm theo thương hiệu
            objBrand.ListProductBrand = webBanHangASP.Product_0242.Where(n => n.BrandId == Id).OrderByDescending(n => n.Id).ToPagedList(pageNumber, limit);



            return View(objBrand);
        }
    }
}