using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Class;
namespace MvcOnlineTicariOtomasyon.Controllers
{
   
    public class toDoController : Controller
    {
        Context context = new Context();
        // GET: toDo
        public ActionResult Index()
        {
            var deger1 = context.Customers.Count().ToString();
            ViewBag.d1 = deger1;
            
            var deger2 = context.Products.Count().ToString();
            ViewBag.d2 = deger2;
           
            var deger3 = context.Categories.Count().ToString();
            ViewBag.d3 = deger3;

            var deger4 = context.Customers.Select(x => x.CustomerCity).Distinct().Count().ToString();
            ViewBag.d4 = deger4;

            var toDo = context.toDos.ToList();

            return View(toDo);
        }

    }
}