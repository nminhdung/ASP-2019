﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class BrandMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên thương hiệu")]
        [Display(Name="Tên thương hiệu")]
        public string Name { get; set; }
        [Display(Name="Hình đại diện")]
        public string Avatar { get; set; }
        [Display(Name="Hiển thị trên trang chủ")]
        public Nullable<bool> ShowOnHomePage { get; set; }
        public string Slug { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<bool> Deleted { get; set; }
    }
}