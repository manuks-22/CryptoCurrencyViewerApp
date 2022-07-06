using CryptoCurrencyApp.Infrastructure.Logging;
using CryptoCurrencyApp.Service;
using CryptoCurrencyApp.Service.Configuration;
using CryptoCurrencyApp.Service.WebClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CryptoCurrencyViewApp
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
            services.AddHttpClient();
            services.AddSingleton(typeof(ILogManager), new LogManager());
            services.AddRazorPages();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CryptoCurrencyViewApp", Version = "v1" });
            });

            services.AddScoped<IWebClient, WebClient>();

            services.AddScoped<ICryptoCurrenyService, CryptoCurrenyService>();
            services.AddScoped<ICoinMarketCapConfiguration, CoinMarketCapConfiguration>();

            services.AddScoped<IExchangeRateConfiguration, ExchangeRateConfiguration>();
            services.AddScoped<IExchangeRateService, ExchangeRateService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseExceptionHandler("/error");
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CryptoCurrencyViewApp v1"));
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
