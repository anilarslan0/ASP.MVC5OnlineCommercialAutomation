using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Class;
namespace MvcOnlineTicariOtomasyon.Controllers
{
   
    public class ProductController : Controller
    {
        // GET: Product

        Context context = new Context();
        [Authorize]
        public ActionResult Index(string urun)
        {
            var urunler = from x in context.Products select x;
            if (!string.IsNullOrEmpty(urun))
            {
                urunler = urunler.Where(y => y.ProductName.Contains(urun));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger1 = (from x in context.Categories.ToList() 
                                           select new SelectListItem 
                                           { 
                                               Text = x.CategoryName, 
                                               Value = x.CategoryId.ToString() 
                                           
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var deger = context.Products.Find(id);
            deger.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()

                                           }).ToList();

            ViewBag.dgr1 = deger1;

            var urundeger = context.Products.Find(id);
            return View("UrunGetir", urundeger);
        }

        public ActionResult UrunGuncelle(Product product)
        {
            var urun = context.Products.Find(product.ProductId);
            urun.ProductFirstPrice = product.ProductFirstPrice;
            urun.Status = product.Status;
            urun.CategoryId = product.CategoryId;
            urun.ProductBrand = product.ProductBrand;
            urun.ProductStock = product.ProductStock;
            urun.ProductImage = product.ProductImage;
            urun.ProductName = product.ProductName;
            urun.ProductSalePrice = product.ProductSalePrice;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult UrunListesi()
        {
            var degerler = context.Products.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> deger3 = (from x in context.Staffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.StaffName + " " + x.StaffSurname,
                                               Value = x.StaffId.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            var deger4 = context.Products.Find(id);
            ViewBag.dgr4= deger4.ProductId;

            ViewBag.dgr5 = deger4.ProductSalePrice;
            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SalesAction saleAction)
        {
            saleAction.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SalesActions.Add(saleAction);
            context.SaveChanges();
            return RedirectToAction("Index","Sale");
        }


    }
}