using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightControlWeb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



namespace FlightControlWeb
{
    public class Startup
    {
        /*
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();

           // app.UseAuthorization();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("html\\index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();
            



            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                
                //endpoints.MapRazorPages();
                endpoints.MapRazorPages();

            });
        }
    }
    */
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<AllFlightPlans>();
            services.AddControllers();
            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("html\\flightPlan.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();
            /*
            app.UseDefaultFiles(new DefaultFilesOptions
            {
                DefaultFileNames = new
                        List<string> { "html\\htmlpage.html" }
            });
            app.UseHttpsRedirection();
            */
           // app.UseStaticFiles();
            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
