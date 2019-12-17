using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NasaExoPlanets
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        //private void LoadPlanets(IServiceCollection services)
        //{
        //    FileStream fileStream = new FileStream("Files/planets_2019.05.27_03.23.59.csv", FileMode.Open);
        //    List<Planet> _planets = new List<Planet>();
        //    using (StreamReader reader = new StreamReader(fileStream))
        //    {
        //        string line;
        //        do
        //        {
        //            line = reader.ReadLine();
        //            if (line?.StartsWith('#') ?? true) continue;
        //            var split = line.Split(',');
        //            _planets.Add(new Planet
        //            {
        //                pl_hostname = split[0],
        //                pl_letter = split[1],
        //                pl_discmethod = split[3],
        //                pl_facility = split[67]
        //            });
        //        } while (!string.IsNullOrWhiteSpace(line));
        //    }

        //    var planetsSingleton = new PlanetsSingleton(_planets);
        //    services.AddSingleton<IPlanets>(planetsSingleton);
        //}

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
