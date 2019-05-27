namespace NasaExoplanetQuery
{
    using System.Collections.Generic;
    using System.IO;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using NasaExoplanetQuery.Model;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            var _planets = this.LoadPlanetsIntoMemory();
            var planetsSingleton = new PlanetsSingleton(_planets);
            services.AddSingleton<IPlanets>(planetsSingleton);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            this.LoadPlanetsIntoMemory();
        }

        private IEnumerable<Planet> LoadPlanetsIntoMemory()
        {
            FileStream fileStream = new FileStream("Planets/planets_2019.05.27_03.23.59.csv", FileMode.Open);
            List<Planet> _planets = new List<Planet>();
            using (StreamReader reader = new StreamReader(fileStream))
            {
                string line;
                do
                {
                    line = reader.ReadLine();
                    if (line?.StartsWith('#') ?? true) continue;
                    var split = line.Split(',');
                    _planets.Add(new Planet
                    {
                        pl_hostname = split[0],
                        pl_letter = split[1]
                    });
                } while (!string.IsNullOrWhiteSpace(line));
            }

            return _planets;
        }
    }
}
