using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using School_Core.Repositories;
using School_Core.Services;

namespace School_Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<StudentRepository, StudentRepository>();
            builder.Services.AddScoped<TeacherRepository, TeacherRepository>();
            builder.Services.AddScoped<ClassesRepository, ClassesRepository>();
            builder.Services.AddScoped<ClassesStudentRepository, ClassesStudentRepository>();
            builder.Services.AddScoped<UserRepository, UserRepository>();
            builder.Services.AddDbContext<DB>(option =>
            {
                option.UseSqlServer(@"Server=.\SQL2016;Database=Schoo_Core;Trusted_Connection=True;TrustServerCertificate=True");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
#pragma warning disable
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
#pragma warning restore

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");
            //app.MapAreaControllerRoute(
            //    name: "Admin",
            //    areaName: "Admin",
            //    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            //    );

            app.Run();
        }
}
}