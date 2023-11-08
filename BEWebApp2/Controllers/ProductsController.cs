using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEWebApp2.Models;
using System.IO;

namespace BEWebApp2.Controllers
{
    public class ProductsController : Controller
    {
        private StoreMgmtEntities db = new StoreMgmtEntities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category);
            //return View(products.GroupBy(p => p.Category).ToList());
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProID,ProName,CatID,ProImage,NameDecription," +
            "CreatedDate, UploadImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                //bo sung doan code de gan duong dan anh cho ProImage va luu anh vao thu muc Images tren server
                if (product.UploadImage !=null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(product.UploadImage.FileName);
                    product.ProImage = path + filename;
                    product.UploadImage.SaveAs(Path.Combine(Server.MapPath(path),filename));
                }
                product.CreatedDate = DateTime.Today;
                
                //doan code giu nguyen
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            return View(product);
            //return View()
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProID,ProName,CatID,ProImage,NameDecription," +
            "CreatedDate, UploadImage")] Product product)
        {
            if (ModelState.IsValid)
            {
                //bo sung doan code de gan duong dan anh cho ProImage va luu anh vao thu muc Images tren server
                if (product.UploadImage != null)
                {
                    string path = "~/Content/images/";
                    string filename = Path.GetFileName(product.UploadImage.FileName);
                    product.ProImage = path + filename;
                    product.UploadImage.SaveAs(Path.Combine(Server.MapPath(path), filename));
                }
                
                //doan code giu nguyen
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatID = new SelectList(db.Categories, "CatID", "NameCate", product.CatID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
