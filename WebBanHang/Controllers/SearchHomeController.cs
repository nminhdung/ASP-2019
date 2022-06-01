using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;

namespace WebBanHang.Controllers
{
    public class SearchHomeController : Controller
    {
        WebBanHangASPEntities webBanHangASP = new WebBanHangASPEntities();
        // GET: SearchHome
        public ActionResult SearchProduct(string currentFilter, string SearchString, int? page)
        {
            var lstProduct = new List<Product_0242>();
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
                lstProduct = webBanHangASP.Product_0242.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                lstProduct = webBanHangASP.Product_0242.Where(n => n.Deleted == false).ToList();
            }
            ViewBag.CurrentFilter = SearchString;

            //Số lượng item mỗi trang
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sp, sp mới đưa lên đầu
            lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult SearchProductByCategory(string currentFilter, string SearchString, int? page)
        {
            var lstProduct = new List<Product_0242>();


            if (SearchString != null)
            {
                page = 1;

            }
            else
            {
                SearchString = currentFilter;

            }
            string stringConvert = ConvertTextToSlug(SearchString);
            var objCategory = webBanHangASP.Category_0242.Where(n => n.Slug.Contains(stringConvert)).FirstOrDefault();

            //var objCategory = webBanHangASP.Category_0242.Where(n => n.Name== SearchString).FirstOrDefault();
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstProduct = webBanHangASP.Product_0242.Where(n => n.CategoryId == objCategory.Id).ToList();
            }
            else
            {
                lstProduct = webBanHangASP.Product_0242.Where(n => n.Deleted == false).ToList();
            }
            ViewBag.CurrentFilter = SearchString;

            //Số lượng item mỗi trang
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sp, sp mới đưa lên đầu
            lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult SearchProductByBrand(string currentFilter, string SearchString, int? page)
        {
            var lstProduct = new List<Product_0242>();
           
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = currentFilter;
            }
             var objBrand = webBanHangASP.Brand_0242.Where(n => n.Name.Contains(SearchString)).FirstOrDefault();
            if (!string.IsNullOrEmpty(SearchString))
            {
                lstProduct = webBanHangASP.Product_0242.Where(n => n.BrandId == objBrand.Id).ToList();
            }
            else
            {
                lstProduct = webBanHangASP.Product_0242.Where(n => n.Deleted == false).ToList();
            }
            ViewBag.CurrentFilter = SearchString;
            //Số lượng item mỗi trang
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sp, sp mới đưa lên đầ u
            lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));
        }
        public string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
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
            return convertToUnSign3(sb.ToString());
        }

    }
}