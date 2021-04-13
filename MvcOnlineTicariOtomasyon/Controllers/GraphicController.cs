using MvcOnlineTicariOtomasyon.Models.Class;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GraphicController : Controller
    {
        // GET: Graphic
        Context context = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Grafik()
        {
            var graphicDraw = new Chart(600,600);
            graphicDraw.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" },
                yValues: new[] { 85, 66, 98 }).Write();
            return File(graphicDraw.ToWebImage().GetBytes(), "image/jpeg");

        }

        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = context.Products.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.ProductName));
            sonuclar.ToList().ForEach(y=>yvalue.Add(y.ProductStock));
            var grafic = new Chart(width: 800, height: 800).AddTitle("Stoklar").AddSeries(chartType: "Pie", name: "Stok", xValue: xvalue, yValues: yvalue);
            return File(grafic.ToWebImage().GetBytes(), "image/jpeg");

        }

        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(),JsonRequestBehavior.AllowGet);
        }

        public List<ChartFor> ProductList()
        {
            List<ChartFor> chart = new List<ChartFor>();
            using (var context=new Context())
            {
                chart = context.Products.Select(x => new ChartFor
                {
                    ProductName = x.ProductName,
                    Stok = x.ProductStock
                }).ToList();
            }
            return chart;
        }



    }
}