using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Class
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StaffName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string StaffSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string StaffImage { get; set; }
        public ICollection<SalesAction> SalesActions { get; set; }
        public Department Department { get; set; }
    }
}