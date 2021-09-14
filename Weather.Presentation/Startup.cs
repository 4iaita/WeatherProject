using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Data.EF;
using Weather.Data.Interfaces;
using Weather.Data.Repositories;
using Weather.Domain.Interfaces;
using Weather.Domain.Services;
using Weather.Presentation.Mapping;

namespace Weather.Presentation
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
            services.AddDbContext<DatabaseContext>(options =>
                     options.UseSqlServer(
                         Configuration.GetConnectionString("DefaultConnection"),
                         b => b.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
            services.AddMemoryCache();

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ITemperatureLogRepository, TemperatureLogRepository>();
            services.AddTransient<IWeatherConditionRepository, WeatherConditionRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IWeatherService, WeatherService>();
            services.AddSingleton(new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); }).CreateMapper());
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "BookStore API",
                    Version = "v1"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
