using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcOnlineTicariOtomasyon.Models.Class
{
    public class CargoFollow
    {
        [Key]
        public int CargoFollowId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string FollowCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Description { get; set; }
        public DateTime Date { get; set; }

    }
}