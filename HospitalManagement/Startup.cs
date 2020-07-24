using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalManagement.DAL;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace HospitalManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            var optionsBuilder = new DbContextOptionsBuilder<PatientDAL>();
            optionsBuilder.UseSqlServer(Configuration["conStr"].ToString());
            PatientDAL dal = new PatientDAL(Configuration["conStr"].ToString());

            // dal.Database.EnsureCreated();
            //end here
            services.AddDbContext<PatientDAL>(
                options => options.UseSqlServer(Configuration["conStr"].ToString()));


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                   .AddJwtBearer(options =>
                   {
                       options.TokenValidationParameters = new TokenValidationParameters
                       {
                           ValidateIssuer = true,
                           ValidateAudience = true,
                           ValidateLifetime = true,
                           ValidateIssuerSigningKey = true,
                           ValidIssuer = "shivani",
                           ValidAudience = "shivani",
                           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("238420983409284098230948"))
                       };
                   });



            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddCors(options =>
                          options.AddPolicy("MyAllowSpecificOrigins",
                            builder =>
                            {
                                builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();



                            }));
            services.AddControllersWithViews().AddNewtonsoftJson(options => options.
            SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );



            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        }

        //        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        //        {
        //            app.UseAuthentication();
        //            if (env.IsDevelopment())
        //            {
        //                app.UseDeveloperExceptionPage();
        //            }
        //            else
        //            {
        //                app.UseExceptionHandler("/Home/Error");
        //                app.UseHsts();
        //            }
        //            app.UseHttpsRedirection();
        //            app.UseStaticFiles();
        //            app.UseCookiePolicy();
        //            app.UseCors("MyAllowSpecificOrigins");



        //            app.UseMvc(routes =>
        //            {
        //                routes.MapRoute(
        //                    name: "default",
        //                    template: "{controller=Patient}/{action=Add}");


        //            });


        //        }
        //    }
        //}
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAuthentication();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCookiePolicy();
            app.UseCors("AllowOriginRule");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
                endpoints.MapControllerRoute(
                    name: "url1",
                    pattern: "Hospital/Register",
                    defaults: new { controller = "Patient", action = "Add" });
                endpoints.MapControllerRoute(
                name: "url2",
                pattern: "Patient/Add",
                defaults: new { controller = "Patient", action = "Add" });
            });
        }
    }
}