using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Admin/Product/
        WebBanHangASPEntities webBanHangASP = new WebBanHangASPEntities();
        public ActionResult Index()
        {
            var lstProduct = webBanHangASP.Product_0242.ToList();
            return View(lstProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product_0242 objProduct)
        {
            try {
                if (objProduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                    fileName = fileName + extension + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objProduct.Avatar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"),fileName));
                }
                webBanHangASP.Product_0242.Add(objProduct);
                webBanHangASP.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return RedirectToAction("Index");

            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objProduct = webBanHangASP.Product_0242.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objProduct = webBanHangASP.Product_0242.Where(n => n.Id == id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product_0242 objPro)
        {
            var objProduct = webBanHangASP.Product_0242.Where(n => n.Id == objPro.Id).FirstOrDefault();
            webBanHangASP.Product_0242.Remove(objProduct);
            webBanHangASP.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}