using EindCasus.Data;
using EindCasus.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EindCasus.Interfaces;
using EindCasus.Services;
using EindCasus.Services.ExtractValueServices;

namespace EindCasus
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
            services.AddControllers();
            services.AddDbContext<CursusDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("CursusDbContext")));
            services.AddScoped<ICursusRepository, CursusRepository>();
            services.AddScoped<IImportCursusRepository, ImportCursusRepository>();
            services.AddScoped<IExtractGroupsService, ExtractGroupsService>();
            services.AddScoped<ICursusImporterService, CursusImporterService>();
            services.AddScoped<IExtractDatum, ExtractDatum>();
            services.AddScoped<IExtractTitel, ExtractTitel>();
            services.AddScoped<IExtractCode, ExtractCode>();
            services.AddScoped<IExtractDuur, ExtractDuur>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
                        .WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
