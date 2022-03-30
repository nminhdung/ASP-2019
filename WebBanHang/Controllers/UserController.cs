using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WebBanHang.Context; 
using System.Web.Mvc;

namespace WebBanHang.Controllers
{
    public class UserController : Controller
    {
        WebBanHangASPEntities webBanHangASP = new WebBanHangASPEntities();
        // GET: User
        public ActionResult Register()
        {
            return View();
        }
        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User_0242 _user)
        {
            if (ModelState.IsValid)
            {
                var check = webBanHangASP.User_0242.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    string getPassword = _user.Password;
                    _user.Password = GetMD5(_user.Password);
                    webBanHangASP.Configuration.ValidateOnSaveEnabled = false;
                    webBanHangASP.User_0242.Add(_user);
                    webBanHangASP.SaveChanges();
                    TempData["msg"] = "Đăng ký thành công";
                    return RedirectToAction("Login");
                }
                else
                {
                    TempData["msg"] = "Đăng ký thất bại";
                    return View();
                }


            }
            return View();


        }

        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(password);
                var data = webBanHangASP.User_0242.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUser"] = data.FirstOrDefault().Id;
                    Session["IsAdmin"] = data.FirstOrDefault().IsAdmin;
                    TempData["msg"] = "Đăng nhập thành công";
                    return Redirect("/");
                }
                else
                {
                    TempData["Error"] = "Đăng nhập thất bại";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            TempData["msg"] = "Đăng xuất thành công";
            return RedirectToAction("Login");
        }
    }
}