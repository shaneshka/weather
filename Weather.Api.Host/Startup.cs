using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Weather.Api.Controllers;
using Weather.Domain;
using Weather.HttpClient;
using Weather.Interfaces;
using Weather.Settings;
using Weather.Storage;

namespace Weather.Api.Host
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //services.AddMemoryCache();
            //services.AddDbContext<WeatherContext>(opt => opt.UseInMemoryDatabase("Weathers"));

            //Add http client services at ConfigureServices(IServiceCollection services) 
            services.AddHttpClient<IWeatherHttpClient, WeatherHttpClient>();

            //services.AddScoped<IWeatherHttpClient, WeatherHttpClient>();

            services.AddSingleton<IWeatherDataProvider, WeatherDataProvider>();
            services.AddSingleton<IWeatherDataUpdater, WeatherDataUpdater>();
            services.AddSingleton<IWeatherSettings, WeatherSettings>();
            services.AddSingleton<IWeatherStorage, WeatherStorage>();


            services.AddMvc().AddApplicationPart(typeof(WeatherController).Assembly).AddControllersAsServices();//AssemblyAssembly.Load("Weather.Api")

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/error");

                app.Map("/error", ap => ap.Run(async context =>
                {
                    await context.Response.WriteAsync("что то пошло н так");
                }));
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePages();
            
            app.UseHttpsRedirection();
            //app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Weather}/{action=Get}/{id?}");
            });
        }
    }


}
