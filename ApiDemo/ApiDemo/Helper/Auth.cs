using ApiDemo.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ApiDemo.Helper
{
    public class Auth: ActionFilterAttribute
    {
        private ApiDemoContext db = new ApiDemoContext();
        public override void OnActionExecuting(HttpActionContext actionContext)
        {


            if (!actionContext.Request.Headers.Contains("token"))
            {
                 actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                return;   
            }

            string token = actionContext.Request.Headers.GetValues("token").First();

            if (db.Employees.FirstOrDefault(e=>e.Token==token)==null)
            {

                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
                return;
            }
            base.OnActionExecuting(actionContext);
        }
    }
}