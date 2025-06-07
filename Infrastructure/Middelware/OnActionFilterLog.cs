using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace Infrastructure.Middelware
{
    public class OnActionFilterLog(IHttpContextAccessor _httpcontext) : IActionFilter
    {


        public void OnActionExecuted(ActionExecutedContext context)
        {
          
            
            //var controller = context.ActionDescriptor.RouteValues["controller"];
            //var action = context.ActionDescriptor.RouteValues["action"];
            //var path = context.HttpContext.Request.Path;
            //var method = context.HttpContext.Request.Method;
            //var user = context.HttpContext.User.Claims.FirstOrDefault(p => p.Type== ClaimTypes.Email)?.Value ?? "Anonimo";
            //Console.WriteLine($" {user} ejecuto {method} {controller}/{action} y el path es {path}");
            //if (method == "PUT" || method == "POST" )
            //{
            //    var statusCode = context.HttpContext.Response.StatusCode;
            //    if (statusCode == 200 || statusCode == 201)
            //    {
            //      var IdAction = context.ActionDescriptor.Id;
            //      Console.WriteLine($" eNTROOO {user} ejecuto {method} {controller}/{action} y el path es {path} y el id es {IdAction}");
            //    }

            //}
           
           

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {         
            
        }
    }
}
