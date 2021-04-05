using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Class;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category

        Context context = new Context();
        public ActionResult Index(int page=1)
        {
            var degerler = context.Categories.ToList().ToPagedList(page,5);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KategoriEkle(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = context.Categories.Find(id);
            context.Categories.Remove(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = context.Categories.Find(id);
            return View("KategoriGetir", kategori)
;        }

        public ActionResult KategoriGuncelle(Category category)
        {
            var kategori = context.Categories.Find(category.CategoryId);
            kategori.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}