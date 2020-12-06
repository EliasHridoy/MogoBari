using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using MogobariWebAPI.Helper;
using MogobariWebAPI.Models;
using MogobariWebAPI.BL.Interface;
using MogobariWebAPI.BL;
using Microsoft.AspNetCore.Internal;

namespace MogobariWebAPI
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

                        
            services.AddDbContext<Mogobari_dbContext>(opts => 
            opts.UseSqlServer(Configuration.GetConnectionString("MogoBari_Db")));
            
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);



            services.AddScoped<IPictureManager, PictureManager>();

            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MogoBari API", Version = "v1.0" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(ui =>
            {
                ui.SwaggerEndpoint("/swagger/v1/swagger.json", "MogoBari API Endpoint");
                ui.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }
    }
}
