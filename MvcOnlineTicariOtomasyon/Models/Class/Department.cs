using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Class
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string DepartmentName { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}