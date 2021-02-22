using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Class
{
    public class SalesAction
    {
        [Key]
        public int SaleId { get; set; }
        //product
        //Custumer
        //staff
        public DateTime Date { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }
        public Staff Staff { get; set; }



    }
}