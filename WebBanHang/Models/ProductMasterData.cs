using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public partial class ProductMasterData
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Vui lòng nhập trường này")]
        [Display(Name="Tên sản phẩm")]
        public string Name { get; set; }
        [Display(Name = "Hình đại diện")]
        public string Avatar { get; set; }
        [Display(Name = "Danh mục")]
        public Nullable<int> CategoryId { get; set; }
        [Display(Name = "Thương hiệu")]
        public Nullable<int> BrandId { get; set; }
        [Display(Name = "Mô tả chi tiết")]
        public string FullDescription { get; set; }
        [Display(Name = "Giá gốc")]
        public Nullable<double> Price { get; set; }
        [Display(Name = "Giá giảm")]
        public Nullable<double> PriceDiscount { get; set; }
        public string Slug { get; set; }
        [Display(Name = "Loại sản phẩm")]
        public Nullable<int> TypeId { get; set; }
        [Display(Name = "Mô tả ngắn")]
        public string ShortDesc { get; set; }

    }
}