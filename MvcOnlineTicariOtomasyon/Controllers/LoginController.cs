using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MvcOnlineTicariOtomasyon.Models.Class;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context context = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial1(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult CustomerLogin1()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult CustomerLogin1(Customer custom)
        {
            var bilgiler = context.Customers.FirstOrDefault(x => x.CustomerMail == custom.CustomerMail && x.CustomerSifre==custom.CustomerSifre);
            if (bilgiler !=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CustomerMail, false);
                Session["CustomerMail"] = bilgiler.CustomerMail.ToString();
                return RedirectToAction("Index","CustomerPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
          
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult AdminLogin(Admin admin)
        {
            var bilgiler = context.Admins.FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.AdminUserName, false);
                Session["AdminUserName"] = bilgiler.AdminUserName.ToString();
                return RedirectToAction("Index","Category");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
        }

    }
}