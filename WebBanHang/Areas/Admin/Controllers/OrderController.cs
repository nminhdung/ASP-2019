using PagedList;
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
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstOrder = new List<Order_0242>();

            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstOrder = webBanHangASP.Order_0242.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstOrder = webBanHangASP.Order_0242.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số lượng item mỗi trang
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sp, sp mới đưa lên đầu
            lstOrder = lstOrder.OrderByDescending(n => n.Id).ToList();
            return View(lstOrder.ToPagedList(pageNumber, pageSize));
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