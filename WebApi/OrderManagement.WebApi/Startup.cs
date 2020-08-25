using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using OrderManagement.Models;
using OrderManagement.WebApi.Data;
using OrderManagement.WebApi.Services;
using Microsoft.OpenApi.Models;

namespace OrderManagement.WebApi
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
            services.AddDbContext<OrderManagementDbContext>(opt =>
               opt.UseSqlite( Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c=>
                    c.SwaggerDoc("v1", 
                        new OpenApiInfo 
                        { 
                            Title = "Order API", 
                            Version = "v1" , 
                            Description="This is a Orders API to test latest technologies in the .NET world",
                            Contact=
                            new OpenApiContact{
                                Name="Darth Vader", 
                                Email="Darth.Vader@DeathStar.com",
                                Url=new Uri("https://en.wikipedia.org/wiki/Death_Star")
                                }
                        }
                        )
                    );
            services.AddHealthChecks();
            services.AddScoped<ICustomerDataService,CustomerDataService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        { 
            if (env.EnvironmentName == "Development")
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseCors(policy => 
            policy.WithOrigins("http://localhost:5000", "https://localhost:5001")
            .AllowAnyMethod()
             .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization)
             .AllowCredentials());
            app.UseHttpsRedirection();
            app.UseRouting();
            
             // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order API V1");
                c.RoutePrefix = string.Empty;
            });
             app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/healthcheck");
                endpoints.MapControllers();
            });
        }
    }
}