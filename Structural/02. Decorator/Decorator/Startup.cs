using Decorator.Services.OpenWeatherMap;
using Decorator.Services.WeatherInterface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Decorator
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
            services.AddControllersWithViews();
            services.AddMemoryCache();

            // string apiKey = Configuration.GetValue<string>("OpenWeatherMapApiKey");
            // services.AddScoped<IWeatherService>(serviceProvider => new WeatherService(apiKey));

            services.AddScoped<IWeatherService>(serviceProvider =>
            {
                string apiKey = Configuration.GetValue<string>("OpenWeatherMapApiKey");
                var logger = serviceProvider.GetService<ILogger<WeatherServiceLoggingDecorator>>();
                var memoryCache = serviceProvider.GetService<IMemoryCache>();

                IWeatherService concrete = new WeatherService(apiKey);
                IWeatherService withLogging = new WeatherServiceLoggingDecorator(concrete, logger);
                IWeatherService withCaching = new WeatherServiceCachingDecorator(withLogging, memoryCache);

                return withCaching;
            });

            //// fluent syntax with Scrutor lib
            //string apiKey = Configuration.GetValue<string>("OpenWeatherMapApiKey");
            //services.AddScoped<IWeatherService>(serviceProvider => new WeatherService(apiKey));
            //services.Decorate<IWeatherService>((inner, provider) => new WeatherServiceLoggingDecorator(
            //    inner, provider.GetService<ILogger<WeatherServiceLoggingDecorator>>()));
            //services.Decorate<IWeatherService>((inner, provider) => new WeatherServiceCachingDecorator(
            //    inner, provider.GetService<IMemoryCache>()));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
