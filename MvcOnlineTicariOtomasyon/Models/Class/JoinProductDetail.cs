using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Class
{
    public class JoinProductDetail
    {
        public IEnumerable<Product> Deger1 { get; set; }
        public IEnumerable<Detail> Deger2 { get; set; }
    }
}