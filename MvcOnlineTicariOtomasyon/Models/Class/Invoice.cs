using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Class
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public string InvoiceSerialNo { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(6)]
        public string InvoiceQueueNo { get; set; }
        public DateTime Date { get; set; }

        [Column(TypeName = "char")]
        [StringLength(5)]
        public string Time { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string TaskOffice { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Exporter { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Buyer { get; set; }


        public decimal TotalAmount { get; set; }
        public ICollection<InvoiceContent> InvoiceContents { get; set; }


    }
}