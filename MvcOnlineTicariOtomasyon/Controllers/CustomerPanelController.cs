using MvcOnlineTicariOtomasyon.Models.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CustomerPanelController : Controller
    {
        Context context = new Context();
        // GET: CustomerPanel
      
        public ActionResult Index()
        {
            var mail = (string)Session["CustomerMail"];
            var degerler = context.messages.Where(x=>x.Receiver==mail).ToList();
            ViewBag.m = mail;
            var mailId = context.Customers.Where(x => x.CustomerMail == mail).Select(y => y.CustomerId).FirstOrDefault();
            ViewBag.mId = mailId;

            var toplamSatis = context.SalesActions.Where(x => x.CustomerId == mailId).Count();
            ViewBag.toplamSatis = toplamSatis;

            var toplamTutar = context.SalesActions.Where(x => x.CustomerId == mailId).Sum(y => y.TotalAmount);
            ViewBag.toplamTutar = toplamTutar;

            var toplamUrunSayisi = context.SalesActions.Where(x => x.CustomerId == mailId).Sum(y=>y.Piece);
            ViewBag.toplamUrun = toplamUrunSayisi;

            var adSoyad = context.Customers.Where(x => x.CustomerMail == mail).Select(y => y.CustomerName + " " + y.CustomerSurname).FirstOrDefault();
            ViewBag.adSoyad = adSoyad;

        

            return View(degerler);
        }
       
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CustomerMail"];
            var id = context.Customers.Where(x => x.CustomerMail == mail.ToString()).Select(y => y.CustomerId).FirstOrDefault();
            var degerler = context.SalesActions.Where(x => x.CustomerId == id).ToList();

            return View(degerler);
        }
     
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CustomerMail"];
            var mesajlar = context.messages.Where(x=>x.Receiver==mail).OrderByDescending(x=>x.MessageId).ToList();
            var gelensayisi = context.messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelensayisi;
            var gönderilenSayisi = context.messages.Count(x => x.Sender == mail).ToString();
            ViewBag.GönderilenMesajSayisi = gönderilenSayisi;
            return View(mesajlar);
        }

       
        public ActionResult GönderilenMesajlar()
        {
            var mail = (string)Session["CustomerMail"];
            var mesajlar = context.messages.Where(x => x.Sender == mail).OrderByDescending(z=>z.MessageId).ToList();
            var gönderilenSayisi = context.messages.Count(x => x.Sender == mail).ToString();
            ViewBag.GönderilenMesajSayisi = gönderilenSayisi;
            var gelensayisi = context.messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelensayisi;
            return View(mesajlar);
        }
        
        public ActionResult MessageDetay(int id)
        {
            var degerler = context.messages.Where(x => x.MessageId == id).ToList();
            var mail = (string)Session["CustomerMail"];
            var gönderilenSayisi = context.messages.Count(x => x.Sender == mail).ToString();
            ViewBag.GönderilenMesajSayisi = gönderilenSayisi;
            var gelensayisi = context.messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelensayisi;
            return View(degerler);
        }


    
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["CustomerMail"];
            var gönderilenSayisi = context.messages.Count(x => x.Sender == mail).ToString();
            ViewBag.GönderilenMesajSayisi = gönderilenSayisi;
            var gelensayisi = context.messages.Count(x => x.Receiver == mail).ToString();
            ViewBag.d1 = gelensayisi;
            return View();
        }
       
        [HttpPost]
        public ActionResult YeniMesaj(Message message)
        {
            var mail = (string)Session["CustomerMail"];
            message.Sender = mail;
            context.messages.Add(message);
            context.SaveChanges();
            return View();
        }

        public ActionResult KargoTakip(string p)
        {
            var k = from x in context.CargoDetails select x;
            k = k.Where(y=>y.FollowCode.Contains(p));
            return View(k.ToList());
        }

        public ActionResult CariKargoTakip(string id)
        {
            var degerler = context.cargoFollows.Where(x => x.FollowCode == id).ToList();

            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult Setting()
        {
            var mail = (string)Session["CustomerMail"];
            var id = context.Customers.Where(x => x.CustomerMail == mail).Select(y => y.CustomerId).FirstOrDefault();
            var customerFind = context.Customers.Find(id);
            return PartialView("Setting",customerFind);
        }

        public ActionResult UpdateProfil(Customer customer)
        {
            var custom = context.Customers.Find(customer.CustomerId);
            custom.CustomerName = customer.CustomerName;
            custom.CustomerSurname = customer.CustomerSurname;
            custom.CustomerSifre = customer.CustomerSifre;
            custom.CustomerCity = customer.CustomerCity;
            custom.CustomerMail = customer.CustomerMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}