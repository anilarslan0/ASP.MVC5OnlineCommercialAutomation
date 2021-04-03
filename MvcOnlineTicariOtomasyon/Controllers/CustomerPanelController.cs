using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CustomerPanelController : Controller
    {
        // GET: CustomerPanel
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}