using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        WebBanHangASPEntities webBanHangASP = new WebBanHangASPEntities();
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstUser = new List<User_0242>();

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
                lstUser = webBanHangASP.User_0242.Where(n => n.FirstName.Contains(SearchString)).ToList();
            }
            else
            {
                lstUser = webBanHangASP.User_0242.ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số lượng item mỗi trang
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sp, sp mới đưa lên đầu
            lstUser = lstUser.OrderByDescending(n => n.Id).ToList();
            return View(lstUser.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User_0242 objUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    webBanHangASP.User_0242.Add(objUser);
                    webBanHangASP.SaveChanges();
                    return RedirectToAction("Index");

                } catch
                {
                    return RedirectToAction("Create");
                }
             
            }
                return View();
        }
        [HttpGet]
        public ActionResult Details(int Id)
        {
            var objUser = webBanHangASP.User_0242.Where(n => n.Id == Id).FirstOrDefault();
            return View(objUser);
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            var objUser = webBanHangASP.User_0242.Where(n => n.Id == Id).FirstOrDefault();
            return View(objUser);
        }
        [HttpPost]
        public ActionResult Delete(User_0242 objUser)
        {
            var objUs = webBanHangASP.User_0242.Where(n => n.Id == objUser.Id).FirstOrDefault();
            webBanHangASP.User_0242.Remove(objUs);
            webBanHangASP.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objUser = webBanHangASP.User_0242.Where(n => n.Id == id).FirstOrDefault();
            return View(objUser);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, User_0242 objUser)
        {
            webBanHangASP.Entry(objUser).State = EntityState.Modified;
            webBanHangASP.SaveChanges();
            return View(objUser);
        }
    }
}