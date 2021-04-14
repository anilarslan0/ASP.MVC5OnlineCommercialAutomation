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
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CustomerMail"];
            var degerler = context.Customers.FirstOrDefault(x=>x.CustomerMail==mail);
            ViewBag.m = mail;
            return View(degerler);
        }
        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CustomerMail"];
            var id = context.Customers.Where(x => x.CustomerMail == mail.ToString()).Select(y => y.CustomerId).FirstOrDefault();
            var degerler = context.SalesActions.Where(x => x.CustomerId == id).ToList();

            return View(degerler);
        }
        [Authorize]
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

        [Authorize]
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
        [Authorize]
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


        [Authorize]
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
        [Authorize]
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

    }
}