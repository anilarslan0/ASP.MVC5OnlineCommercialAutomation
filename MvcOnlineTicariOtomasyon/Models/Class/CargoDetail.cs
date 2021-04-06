using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Class
{
    public class CargoDetail
    {   
        [Key]
        public int CargoDetailId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(300)]
        public string Description { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]

        public string FollowCode { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string Staff { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(25)]
        public string Buyer { get; set; }

        public DateTime Date { get; set; }
    }
}