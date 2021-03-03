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
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SalesAction salesAction)
        {
            context.SalesActions.Add(salesAction);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}