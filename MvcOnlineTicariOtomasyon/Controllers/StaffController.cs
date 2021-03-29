using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Class;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    
    public class StaffController : Controller
    {
        Context context = new Context();
        // GET: Staff
        public ActionResult Index()
        {
            var degerler = context.Staffs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniPersonel()
        {
            List<SelectListItem> deger1 = (from x in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()

                                           }).ToList();

            ViewBag.dgr1 = deger1;
            return View();
        }

        [HttpPost]
        public ActionResult YeniPersonel(Staff staff)
        {
            context.Staffs.Add(staff);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()

                                           }).ToList();

            ViewBag.dgr1 = deger1;
            var personel = context.Staffs.Find(id);
            return View("PersonelGetir",personel);
        }
        public ActionResult PersonelGuncelle(Staff staff)
        {
            var personel = context.Staffs.Find(staff.StaffId);
            personel.StaffName = staff.StaffName;
            personel.StaffSurname = staff.StaffSurname;
            personel.StaffImage = staff.StaffImage;
            personel.DepartmentId = staff.DepartmentId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelList()
        {
            var liste = context.Staffs.ToList();
            return View(liste);
        }
    }
}