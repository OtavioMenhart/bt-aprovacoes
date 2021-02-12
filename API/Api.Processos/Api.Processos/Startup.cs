using Api.Processos.CrossCutting.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Processos
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
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);

            services.AddControllers();
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "API .Net Core Processos",
                    Description = "Teste BT",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "Ot�vio", Email = "otaviomenhart@hotmail.com" }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);
                //x.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                //{
                //    Description = "Entre com o token JWT",
                //    Name = "Authorization",
                //    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                //    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey
                //});

                //x.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                //{{
                //    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                //    {
                //        Reference = new Microsoft.OpenApi.Models.OpenApiReference
                //        {
                //            Id = "Bearer",
                //            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme
                //        }
                //    }, new List<string>() }
                //});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiNetCoreProcessos");
                x.RoutePrefix = string.Empty;
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