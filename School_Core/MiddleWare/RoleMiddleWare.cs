using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

namespace School_Core.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RoleMiddleWare
    {
        private readonly RequestDelegate _next;

        public RoleMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            if (httpContext.Request.Path.StartsWithSegments("/admin"))
            {
                if (!httpContext.User.Identity!.IsAuthenticated)
                {
                    httpContext.Response.Redirect("/Account/Login");
                }
                else if (!httpContext.User.IsInRole("Admin"))
                {
                    httpContext.Response.Redirect("/Home/Privacy");
                }
            }
            else if (httpContext.Request.Path.StartsWithSegments("/teacher"))
            {
                if (!httpContext.User.Identity!.IsAuthenticated)
                {
                    httpContext.Response.Redirect("/Account/Login");
                }
                else if (!httpContext.User.IsInRole("Teacher"))
                {
                    httpContext.Response.Redirect("/Home/Privacy");
                }
            }
            else if (httpContext.Request.Path.StartsWithSegments("/student"))
            {
                if (!httpContext.User.Identity!.IsAuthenticated)
                {
                    httpContext.Response.Redirect("/Account/Login");
                }
                else if (!httpContext.User.IsInRole("Student"))
                {
                    httpContext.Response.Redirect("/Home/Privacy");
                }
            }
            await _next(httpContext);
        }
    }
}
