using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiDemo.Models
{
    public class Department
    {
        public int Id { get; set; }
        [StringLength(250)]
        [Required]
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
    }
}