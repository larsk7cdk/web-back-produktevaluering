using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using web_back_produktevaluering.web.Models;

namespace web_back_produktevaluering.web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            var connection = "Data Source=Database/db.db";
            services.AddDbContext<AppDbContext>();

            services.AddMvc();
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseStatusCodePages("text/plain", "HTTP Error - Status Code: {0}");
        }
    }
}