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
        public DateTime Date { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }

        public int ProductId { get; set; }

        public int StaffId { get; set; }
        public int CustomerId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Staff Staff { get; set; }



    }
}