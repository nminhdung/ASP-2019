using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class OrderMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập trường này")]
        [Display(Name="Tên đơn hàng")]
        public string Name { get; set; }
        [Display(Name="Giá")]
        public Nullable<double> Price { get; set; }
        [Display(Name="Trạng thái")]
        public Nullable<bool> Status { get; set; }
        [Display(Name="Ngày tạo")]
        public Nullable<System.DateTime> CreatedOnUtc { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
}