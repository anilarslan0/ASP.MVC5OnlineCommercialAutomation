using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Class;
namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context context = new Context();
        public ActionResult Index()
        {
            JoinProductDetail productDetail = new JoinProductDetail();
            //var degerler = Context.Products.Where(x=>x.ProductId==1).ToList();
            productDetail.Deger1 = context.Products.Where(x => x.ProductId == 1).ToList();
            productDetail.Deger2 = context.Details.Where(y => y.DetailId == 1).ToList();
            return View(productDetail);
        }
    }
}