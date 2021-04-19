using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Class;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department

        Context context = new Context();
        public ActionResult Index()
        {
            var degerler = context.Departments.Where(x => x.Status == true).ToList();
            return View(degerler);
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Department department)
        {
            context.Departments.Add(department);
            department.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {

            return View();
        }


        public ActionResult DepartmanSil(int id)
        {
            var departman = context.Departments.Find(id);
            departman.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departman = context.Departments.Find(id);
            return View("DepartmanGetir", departman);
        }
        public ActionResult DepartmanGuncelle(Department department)
        {
            var departman = context.Departments.Find(department.DepartmentId);
            departman.DepartmentName = department.DepartmentName;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay(int id)
        {
            var degerler = context.Staffs.Where(x => x.DepartmentId == id).ToList();
            var departman = context.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.departman = departman;
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = context.SalesActions.Where(x => x.StaffId == id).ToList();
            var personel = context.Staffs.Where(x => x.StaffId == id).Select(y => y.StaffName + " " + y.StaffSurname).FirstOrDefault();
            ViewBag.dpersonel = personel;
            return View(degerler);
        }
    }
}