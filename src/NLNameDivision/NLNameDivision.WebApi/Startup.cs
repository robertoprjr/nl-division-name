using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLNameDivision.Cross.Constant;
using NLNameDivision.Service.Abstraction;
using NLNameDivision.Service;
using NLNameDivision.Service.MapperProfile;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen();
            
            ConfigureBusinessServices(services);
        }
        
        public void ConfigureBusinessServices(IServiceCollection services)
        {
            services.TryAddScoped<IDefaultService, DefaultService>();
            services.TryAddScoped<IParticleService, ParticleService>();
            services.TryAddScoped<INameDivisionService, NameDivisionService>();

            services.AddAutoMapper(typeof(NameSliceMapperProfile));
            services.AddAutoMapper(typeof(NameSlicesMapperProfile));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(GeneralConstant.SwaggerJsonUrl , GeneralConstant.TitleApi);
                c.RoutePrefix = string.Empty;
            });
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}