using BEWebApp2.Models;
using BEWebApp2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BEWebApp2.Controllers
{
    public class DetailProductController : Controller
    {
        private StoreMgmtEntities db = new StoreMgmtEntities();

        // GET: DetailProduct
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetailProduct(int? id)
        {
            //List<Product> listProduct=db.Products.ToList();
            //List<Color> colorList = db.Colors.ToList();
            //return View();


            if (id != null)
            {
                ProDetail pro = db.ProDetails.FirstOrDefault(p => p.ProDeID == id);
                DetailProductVM detailProductVM = new DetailProductVM
                {
                    // lay thong tin cua hang Prodetail
                    ProDeID = pro.ProDeID,
                    Price = pro.Price,
                    RemainQuantity = pro.RemainQuantity,
                    SoldQuantity = pro.SoldQuantity,
                    ViewQuantity = pro.ViewQuantity,

                    // Product 
                    ProID = pro.ProID,
                    ProName = pro.Product.ProName,
                    ProImage = pro.Product.ProImage,
                    NameDecription = pro.Product.NameDecription,

                    //  Category table
                    CatID = pro.Product.CatID,
                    NameCate = pro.Product.Category.NameCate,

                    //  Supplier table
                    SupID = pro.SupID,
                    SupName = pro.Supplier.SupName,
                    Address = pro.Supplier.Address,
                    //color table
                    ColorID = pro.ColorID,
                    ColorName = pro.Color.ColorName,
                    RGB = pro.Color.RGB,
                };
                return View(detailProductVM);
            }
            return View();
        }
    }
}
