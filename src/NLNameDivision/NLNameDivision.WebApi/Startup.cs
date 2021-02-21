using System;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using NLNameDivision.Constant;
using NLNameDivision.Service.Abstraction;
using NLNameDivision.Service;

namespace NLNameDivision.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
    
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            
            ConfigureBusinessServices(services);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
        
        public void ConfigureBusinessServices(IServiceCollection services)
        {
            services.TryAddScoped<IParticleService, ParticleService>();
            services.TryAddScoped<INamePartService, NamePartService>();
            services.TryAddScoped<INameDivisionService, NameDivisionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(GeneralConstant.SwaggerJsonUrl , GeneralConstant.TitleApi);
                c.RoutePrefix = string.Empty;
            });
            
            app.UseHttpsRedirection();
        }
    }
}