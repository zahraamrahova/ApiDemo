using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public int ?DepartmentId { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [StringLength(150)]
        public string Surname { get; set; }
        [Required]
        [StringLength(200)]
        public string Email { get; set; }
        [Required]
        [StringLength(250)]
        public string Password { get; set; }
      
        [StringLength(250)]
        public string Token { get; set; }
        public Boolean ?Status { get; set; }
        public Department Department { get; set; }
    }
}