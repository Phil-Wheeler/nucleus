﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using NucleusApi.Data;
using NucleusApi.Models;
using NJsonSchema;
using NSwag.AspNetCore;

namespace NucleusApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors();

            var mongoUserSecret = Configuration["mongodb:user"];
            var mongoPasswordSecret = Configuration["mongodb:password"];
            var mongoInstanceSecret = Configuration["mongodb:instance"];

            services.Configure<Settings>(options => 
            {
                options.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value
                    .Replace("{user}", mongoUserSecret)
                    .Replace("{pass}", mongoPasswordSecret)
                    .Replace("{instance}", mongoInstanceSecret);
                options.Database = Configuration.GetSection("MongoConnection:Database").Value;
            });
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
                app.UseHsts();
            }

            app.UseCors(builder => 
                builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings => 
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "Nucleus API";
                    document.Info.Description = "Testing";
                };
            });
            
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseMvc();

            

        }
    }
}
