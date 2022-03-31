using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebBanHang.Context;
using WebBanHang.Models;
namespace WebBanHang.Context
{
  [MetadataType(typeof(ProductMasterData))]
    public partial class Product_0242
    {
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
    [MetadataType(typeof(CategoryMasterData))]
    public partial class Category_0242
    {
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
    [MetadataType(typeof(BrandMasterData))]
    public partial class Brand_0242
    {
        [NotMapped]
        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
}