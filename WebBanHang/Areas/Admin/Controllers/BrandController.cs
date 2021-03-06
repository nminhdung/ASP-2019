using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;

namespace WebBanHang.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        // GET: Admin/Brand

        WebBanHangASPEntities webBanHangASP = new WebBanHangASPEntities();
        public ActionResult Index(string currentFilter, string SearchString, int? page)
        {
            var lstBrand = new List<Brand_0242>();

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
                lstBrand = webBanHangASP.Brand_0242.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstBrand = webBanHangASP.Brand_0242.Where(n=>n.Deleted==false).ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số lượng item mỗi trang
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sp, sp mới đưa lên đầu
            lstBrand = lstBrand.OrderByDescending(n => n.Id).ToList();
            return View(lstBrand.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Brand_0242 objBrand)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (objBrand.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                        string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objBrand.Avatar = fileName;
                        objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    }
                    objBrand.Slug = ConvertTextToSlug(objBrand.Name);
                    webBanHangASP.Brand_0242.Add(objBrand);
                    webBanHangASP.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Create");
                }
            }
            return View(objBrand);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objBrand = webBanHangASP.Brand_0242.Where(n => n.Id == id).FirstOrDefault();
            return View(objBrand);
        }
        public ActionResult Trash()
        {
            var objBrand = webBanHangASP.Brand_0242.Where(n => n.Deleted == true).ToList();
            return View(objBrand);
        }

        public ActionResult DelTrash(int Id)
        {
            var objBrand = webBanHangASP.Brand_0242.Where(n => n.Id == Id).FirstOrDefault();
            objBrand.Deleted = true;
            webBanHangASP.Entry(objBrand).State = EntityState.Modified;
            webBanHangASP.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Restore(int Id)
        {
            var objBrand = webBanHangASP.Brand_0242.Where(n => n.Id == Id).FirstOrDefault();
            objBrand.Deleted = false;
            webBanHangASP.Entry(objBrand).State = EntityState.Modified;
            webBanHangASP.SaveChanges();
            return RedirectToAction("Index");
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
            if (ModelState.IsValid)
            {
                try
                {
                    if (objBrand.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objBrand.ImageUpload.FileName);
                        string extension = Path.GetExtension(objBrand.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objBrand.Avatar = fileName;
                        objBrand.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    }
                    objBrand.Slug = ConvertTextToSlug(objBrand.Name);
                    webBanHangASP.Entry(objBrand).State = EntityState.Modified;
                    webBanHangASP.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return RedirectToAction("Edit");

                }
            }
            
            return View(objBrand);
        }


        public string ConvertTextToSlug(string s)
        {
            StringBuilder sb = new StringBuilder();
            bool wasHyphen = true;
            foreach (char c in s)
            {
                if (char.IsLetterOrDigit(c))
                {
                    sb.Append(char.ToLower(c));
                    wasHyphen = false;
                }
                else if (char.IsWhiteSpace(c) && !wasHyphen)
                {
                    sb.Append('-');
                    wasHyphen = true;
                }
            }
            // Avoid trailing hyphens
            if (wasHyphen && sb.Length > 0)
                sb.Length--;
            return sb.ToString();
        }
    }
}