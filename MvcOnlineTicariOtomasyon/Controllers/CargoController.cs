using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Class;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context context = new Context();
        public ActionResult Index(string p)
        {
            var cargo = from x in context.CargoDetails select x;
            if (!string.IsNullOrEmpty(p))
            {
                cargo = cargo.Where(y => y.FollowCode.Contains(p));
            }
            return View(cargo.ToList());
        }

        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random random = new Random();
            string[] karakterler = { "A", "B", "C", "D","E","G","F","K","L","M","Z" };
            int k1, k2, k3;
            k1 = random.Next(0,karakterler.Length);
            k2 = random.Next(0, karakterler.Length);
            k3 = random.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = random.Next(100, 1000);
            s2 = random.Next(10, 99);
            s3 = random.Next(10, 99);
            string kod = s1.ToString() + karakterler[k1] + s2 + karakterler[k2] + s3 + karakterler[k3];
            ViewBag.takipkod = kod;
            
            return View();
        }

        [HttpPost]
        public ActionResult YeniKargo(CargoDetail cargoDetail)
        {
            context.CargoDetails.Add(cargoDetail);
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult KargoTakip(string id)
        {
            var degerler = context.cargoFollows.Where(x => x.FollowCode == id).ToList();
           
            return View(degerler);
        }

    }
}