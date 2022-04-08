using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Context;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class PaymentController : Controller
    {
        WebBanHangASPEntities webBanHangASP = new WebBanHangASPEntities();
        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Login", "User");
            }
            else
            {
                //lấy thông tin từ giỏ hàng từ biến session
                var lstCart = (List<CartModel>)Session["cart"];
                //gán dữ liệu cho Order
                Order_0242 objOrder = new Order_0242();
                objOrder.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserId = int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = true;
                //thêm đơn hàng
                webBanHangASP.Order_0242.Add(objOrder);
                //lưu thông tin dữ liệu vào bảng Order
                webBanHangASP.SaveChanges();

                //Lấy OrderId mới lưu vào bảng OrderDetail
                int intOrderId = objOrder.Id;
                List<OrderDetail_0242> lstOrderDetail = new List<OrderDetail_0242>();
                foreach(var item in lstCart)
                {
                    OrderDetail_0242 obj = new OrderDetail_0242();
                    obj.Quantity = item.Quantity;
                    obj.OrderId = intOrderId;
                    obj.ProductId = item.Product.Id;
                    lstOrderDetail.Add(obj);
                }
                webBanHangASP.OrderDetail_0242.AddRange(lstOrderDetail);
                webBanHangASP.SaveChanges();
            }
            return View();
        }
    }
}