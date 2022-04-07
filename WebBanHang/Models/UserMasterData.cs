using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class UserMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập Tên")]
        [DisplayName("Tên")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ")]
        [DisplayName("Họ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập password")]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
    }
}