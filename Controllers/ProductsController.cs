
using NorthwindAngular.Models;
using System.Linq;
using System.Web.Mvc;

namespace NorthwindAngular.Controllers
{
    public class ProductsController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        // GET: Products
        public ActionResult Liste()
        {
            db.Configuration.LazyLoadingEnabled = false;
            ProductsModel model = new ProductsModel();
            model.plist = db.Products.ToList();
            model.clist = db.Categories.Select(x => new DTOs.CategoriesDTO
            {
                CategoryID = x.CategoryID,
                CategoryName = x.CategoryName

            }).ToList();
            model.slist = db.Suppliers.Select(x => new DTOs.SupplierDTO
            {
                SupplierID = x.SupplierID,
                CompanyName = x.CompanyName

            }).ToList();
            model.id = 1;

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Detay(int id)
        {
            db.Configuration.LazyLoadingEnabled = false;
            ProductsModel model = new ProductsModel();
            model.product = db.Products.Find(id);

            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Guncel(Products p)
        {

            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();



            return Json(p, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Ekle(Products p)
        {

            db.Entry(p).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();



            return Json(p, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Sil(Products p)
        {

            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();



            return Json(p, JsonRequestBehavior.AllowGet);
        }
    }
}