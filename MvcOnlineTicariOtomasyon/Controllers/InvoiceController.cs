using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Class;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context context = new Context();
        public ActionResult Index()
        {
            var liste = context.Invoices.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult YeniFatura()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniFatura(Invoice invoice)
        {
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura = context.Invoices.Find(id);
            return View("FaturaGetir", fatura);
        }

        public ActionResult FaturaGuncelle(Invoice f)
        {
            var fatura = context.Invoices.Find(f.InvoiceId);
            fatura.InvoiceSerialNo = f.InvoiceSerialNo;
            fatura.InvoiceQueueNo = f.InvoiceQueueNo;
            fatura.TaskOffice = f.TaskOffice;
            fatura.Time = f.Time;
            fatura.Buyer = f.Buyer;
            fatura.Exporter = f.Exporter;
            fatura.Date = f.Date;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var degerler = context.InvoiceContents.Where(x => x.InvoiceId == id).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalem()
        {
            return View();
        }
        public ActionResult YeniKalem(InvoiceContent ınvoiceContent)
        {
            context.InvoiceContents.Add(ınvoiceContent);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

