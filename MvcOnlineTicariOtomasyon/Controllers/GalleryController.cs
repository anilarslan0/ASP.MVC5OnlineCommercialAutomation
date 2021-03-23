using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Class;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GalleryController : Controller
    {
        Context context = new Context();
        // GET: Gallery
        public ActionResult Index()
        {
            var degerler = context.Products.ToList();
            return View(degerler);
        }
    }
}