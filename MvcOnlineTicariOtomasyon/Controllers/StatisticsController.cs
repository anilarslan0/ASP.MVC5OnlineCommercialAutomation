using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Class;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics

        Context context = new Context();
        public ActionResult Index()
        {
            var deger1 = context.Customers.Count().ToString();
            ViewBag.d1 = deger1;

            var deger2 = context.Products.Count().ToString();
            ViewBag.d2 = deger2;

            var deger3 = context.Staffs.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = context.Categories.Count().ToString();
            ViewBag.d4 = deger4;

            var deger5 = context.Products.Sum(x=>x.ProductStock).ToString();
            ViewBag.d5 = deger5;
            //(from x in context.Products select x.ProductBrand).Distinct().Count().ToString();
            var deger6 = context.Products.Select(x => x.ProductBrand).Distinct().Count().ToString();
            ViewBag.d6 = deger6;
          
            var deger7 = context.Products.Count(x => x.ProductStock < 20).ToString();
            ViewBag.d7 = deger7;

            var deger8 = context.Products.Max(x=>x.ProductSalePrice).ToString();
            ViewBag.d8 = deger8;


            var deger9 = context.Products.Min(x=>x.ProductSalePrice).ToString();
            ViewBag.d9 = deger9;

            var deger10 = context.Products.Count(x=>x.ProductName=="Buzdolabı").ToString();
            ViewBag.d10= deger10;

            var deger11= context.Products.Count(x=>x.ProductName=="Laptop").ToString();
            ViewBag.d11 = deger11;

            var deger12 = context.Products.GroupBy(x => x.ProductBrand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.d12 = deger12;


            var deger13 =context.Products.Where(u=>u.ProductId== context.SalesActions.GroupBy(x=>x.ProductId)
            .OrderByDescending(z=>z.Count()).Select(y=>y.Key).FirstOrDefault()).Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.d13 = deger13;

            var deger14 = context.SalesActions.Sum(x=>x.TotalAmount).ToString();
            ViewBag.d14 = deger14;

            DateTime today = DateTime.Today;
            var deger15 = context.SalesActions.Count(x=>x.Date==today).ToString();
            ViewBag.d15 = deger15;

            var deger16 = context.SalesActions.Where(x=>x.Date==today).Sum(y=>(decimal?)y.TotalAmount).ToString();
            ViewBag.d16 = deger16;

            return View();
        }

        public ActionResult KolayTablolar()
        {
            var sorgu = from x in context.Customers
                        group x by x.CustomerCity into g
                        select new GroupClass
                        {
                            City = g.Key,
                            Count = g.Count()
                        };
            return View(sorgu.ToList());
        }

        public PartialViewResult Partial1()
        {
            var sorgu2 = from x in context.Staffs
                         group x by x.Department.DepartmentName into g
                         select new GroupClass2
                         {
                             Departman = g.Key,
                             Count = g.Count()
                         };
            return PartialView(sorgu2.ToList());
        }

        public PartialViewResult Partial2()
        {
            var sorgu = context.Customers.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial3()
        {
            var sorgu = context.Products.ToList();
            return PartialView(sorgu);
        }

        public PartialViewResult Partial4()
        {
            var sorgu = from x in context.Products
                         group x by x.ProductBrand into g
                         select new GroupClass3
                         {
                             Brand = g.Key,
                             Count = g.Count()
                         };
            return PartialView(sorgu);
        }
    }
}