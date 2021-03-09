using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Class;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SaleController : Controller
    {
        // GET: Expense

        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.SalesActions.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in context.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in context.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName+ " "+ x.CustomerSurname,
                                               Value = x.CustomerId.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in context.Staffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.StaffName + " " + x.StaffSurname,
                                               Value = x.StaffId.ToString()
                                           }).ToList();


            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SalesAction salesAction)
        {
            salesAction.Date =DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SalesActions.Add(salesAction);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Products.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProductName,
                                               Value = x.ProductId.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from x in context.Customers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CustomerName + " " + x.CustomerSurname,
                                               Value = x.CustomerId.ToString()
                                           }).ToList();

            List<SelectListItem> deger3 = (from x in context.Staffs.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.StaffName + " " + x.StaffSurname,
                                               Value = x.StaffId.ToString()
                                           }).ToList();


            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            var deger = context.SalesActions.Find(id);
            return View("SatisGetir",deger);
        }

        public ActionResult SatisGuncelle(SalesAction sale)
        {
            var deger = context.SalesActions.Find(sale.SaleId);
            deger.CustomerId = sale.CustomerId;
            deger.Piece = sale.Piece;
            deger.Price = sale.Piece;
            deger.StaffId = sale.StaffId;
            deger.Date = sale.Date;
            deger.TotalAmount = sale.TotalAmount;
            deger.ProductId = sale.ProductId;
            context.SaveChanges();
            return RedirectToAction("Index");
 
        }

        public ActionResult SatisDetay(int id)
        {
            var degerler = context.SalesActions.Where(x => x.SaleId == id).ToList();
            return View(degerler); 
        }


    }
}