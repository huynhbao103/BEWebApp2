using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BEWebApp2.Models.ViewModel
{
    public class DetailProductVM
    {
        //thong tin Product Detail
        [Key]
        public int ProDeID { get; set; }
        public double Price { get; set; }
        public int RemainQuantity { get; set; }
        public Nullable<int> SoldQuantity { get; set; }
        public Nullable<int> ViewQuantity { get; set; }

        //lay tu bang Product
        public int ProID { get; set; }
        public string ProName { get; set; }
        public string ProImage { get; set; }
        public string NameDecription { get; set; }

        //lay tu bang Category
        public int CatID { get; set; }
        public string NameCate { get; set; }

        //lay tu bang Supplier
        public int SupID { get; set; }
        public string SupName { get; set; }
        public string Address { get; set; }

        //lay tu bang Color
        public int ColorID { get; set; }
        public string ColorName { get; set; }
        public string RGB { get; set; }


        //lưu danh sách từ sản phẩm liên quan 
        public ICollection<DetailProductVM> RelateProducts;
            }
}