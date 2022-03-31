using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        // GET: Admin/Brand
        // GET: Admin/Category
        WebBanHangASPEntities webBanHangASP = new WebBanHangASPEntities();
        public ActionResult Index()
        {
            var lstBrand = webBanHangASP.Brand_0242.ToList();
            return View(lstBrand);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Brand_0242 objBrand)
        {
            try
            {
                if (objBrand.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                    string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                    fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                    objBrand.Avatar = fileName;
                    objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                webBanHangASP.Brand_0242.Add(objBrand);
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
            var objBrand = webBanHangASP.Brand_0242.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objBrand = webBanHangASP.Brand_0242.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Delete(Brand_0242 objBr)
        {
            var objBrand = webBanHangASP.Brand_0242.Where(n => n.Id == objBr.Id).FirstOrDefault();
            webBanHangASP.Brand_0242.Remove(objBrand);
            webBanHangASP.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objBrand = webBanHangASP.Brand_0242.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }
        [HttpPost]
        public ActionResult Edit(int id, Brand_0242 objBrand)
        {
            if (objBrand.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objBrand.Avatar = fileName;
                objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            webBanHangASP.Entry(objBrand).State = EntityState.Modified;
            webBanHangASP.SaveChanges();
            return View(objBrand);
        }
    }
}