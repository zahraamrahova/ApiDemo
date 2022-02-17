using ApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiDemo.DAL
{
    public class ApiDemoContext : DbContext
    {
        public ApiDemoContext ():base("DemoConnection")
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}