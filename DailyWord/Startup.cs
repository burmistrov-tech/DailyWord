using DailyWord.Models;
using DailyWord.Services;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace DailyWord
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
            services
                .Configure<DatabaseSettings>(Configuration.GetSection(nameof(DatabaseSettings)))
                .AddSingleton<IDatabaseSettings>(set => set.GetRequiredService<IOptions<DatabaseSettings>>().Value)
                .AddTransient<IWordDataService<IWordModel>, WordDataService<IWordModel>>()
                .AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app
                .UseRouting()
                .UseStaticFiles()
                .UseHttpsRedirection()
                .UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Main}/{action=Index}");
            });
        }
    }
}
