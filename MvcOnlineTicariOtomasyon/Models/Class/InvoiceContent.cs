using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Class
{
    public class InvoiceContent
    {
        [Key]
        public int InvoiceContentId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public Invoice Invoice { get; set; }
    }
}