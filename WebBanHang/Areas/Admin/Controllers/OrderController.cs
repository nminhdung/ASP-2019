using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        WebBanHangASPEntities webBanHangASP = new WebBanHangASPEntities();
        public ActionResult Index()
        {
            var lstOrder = webBanHangASP.Order_0242.ToList();
            return View(lstOrder);
        }
        public ActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Create(Order_0242 objOrder)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    webBanHangASP.Order_0242.Add(objOrder);
                    webBanHangASP.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Create");
                }
            }
            return View(objOrder);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objOrder = webBanHangASP.Order_0242.Where(n => n.Id == id).FirstOrDefault();
            return View(objOrder);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objOrder = webBanHangASP.Order_0242.Where(n => n.Id == id).FirstOrDefault();
            return View(objOrder);
        }
        [HttpPost]
        public ActionResult Delete(Order_0242 objOr)
        {
            var objOrder = webBanHangASP.Order_0242.Where(n => n.Id == objOr.Id).FirstOrDefault();
            webBanHangASP.Order_0242.Remove(objOrder);
            webBanHangASP.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}