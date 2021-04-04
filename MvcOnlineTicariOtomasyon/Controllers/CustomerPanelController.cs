using MvcOnlineTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CustomerPanelController : Controller
    {
        Context context = new Context();
        // GET: CustomerPanel
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CustomerMail"];
            var degerler = context.Customers.FirstOrDefault(x=>x.CustomerMail==mail);
            ViewBag.m = mail;
            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CustomerMail"];
            var id = context.Customers.Where(x => x.CustomerMail == mail.ToString()).Select(y => y.CustomerId).FirstOrDefault();
            var degerler = context.SalesActions.Where(x => x.CustomerId == id).ToList();

            return View(degerler);
        }
    }
}