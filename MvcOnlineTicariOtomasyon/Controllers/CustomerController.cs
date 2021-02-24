using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Class;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        Context context = new Context();
        public ActionResult Index()
        {
            var musteri = context.Customers.Where(x=>x.Status==true).ToList();
            return View(musteri);
        }
        [HttpGet]
       public ActionResult YeniMüşteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMüşteri(Customer customer)
        {   customer.Status=true;
            context.Customers.Add(customer);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CustomerSil(int id)
        {
            var customer = context.Customers.Find(id);
            customer.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustomerGetir(int id)
        {
            var customer= context.Customers.Find(id);
            return View("CustomerGetir", customer);
        }
        public ActionResult CustomerGuncelle(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerGetir");
            }
            var custo = context.Customers.Find(customer.CustomerId);
            custo.CustomerName = customer.CustomerName;
            custo.CustomerSurname = customer.CustomerSurname;
            custo.CustomerCity = customer.CustomerCity;
            custo.CustomerMail = customer.CustomerMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSatis(int id)
        {
            var degerler = context.SalesActions.Where(x => x.CustomerId == id).ToList();
            var ctmr = context.Customers.Where(x => x.CustomerId == id).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            ViewBag.musteri = ctmr;
            return View(degerler);
        }
    }
}