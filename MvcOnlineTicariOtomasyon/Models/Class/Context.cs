using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Class
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceContent>  InvoiceContents { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SalesAction> SalesActions { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Detail> Details { get; set; }
        public DbSet<toDo> toDos { get; set; }

        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoFollow> cargoFollows { get; set; }
        public DbSet<Message> messages { get; set; }


    }
}