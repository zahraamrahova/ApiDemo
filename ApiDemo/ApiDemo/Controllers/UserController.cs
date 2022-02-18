using ApiDemo.DAL;
using ApiDemo.Helper;
using ApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace ApiDemo.Controllers
{
    public class UserController : ApiController
    {
        private ApiDemoContext db = new ApiDemoContext();
        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login (Employee employee)
        {
            if (employee==null|| string.IsNullOrEmpty(employee.Email)||string.IsNullOrEmpty(employee.Password))
            {
                return BadRequest();
            }

            Employee emp = db.Employees.FirstOrDefault(e => e.Email == employee.Email);
            if (emp==null)
            {
                return NotFound();
            }

            if (!Crypto.VerifyHashedPassword(emp.Password, employee.Password))
            {
                return NotFound();
            }
            string token=Crypto.HashPassword(emp.Email + DateTime.Now.ToString("yyyyMMddHHmmssfff"));

            emp.Token = token;
            db.SaveChanges();

            return Ok(token);
        }

        [HttpPost] 
        [Route("api/register")]
        public IHttpActionResult Register (Employee employee)
        {
            if (employee == null || string.IsNullOrEmpty(employee.Email) || string.IsNullOrEmpty(employee.Password) || string.IsNullOrEmpty(employee.Name) || string.IsNullOrEmpty(employee.Surname))
            {
                return BadRequest();
            }

            Employee emp = db.Employees.FirstOrDefault(e => e.Email == employee.Email);
            if (emp!=null)
            {
                return BadRequest("Bu email istifade olunub");
            }

            employee.Password = Crypto.HashPassword(employee.Password);
            employee.Status = true;
            employee.Token = null;
            db.Employees.Add(employee);
            db.SaveChanges();
            return Ok(employee);
        }


        [Route("api/logout")]
        [HttpGet]
        [Auth] 
        public IHttpActionResult Logout ()
        {
            string token = Request.Headers.GetValues("token").First();

            Employee employee = db.Employees.FirstOrDefault(e => e.Token == token);
            employee.Token = null;
            db.SaveChanges();
            return Ok();

        }

    }
}
