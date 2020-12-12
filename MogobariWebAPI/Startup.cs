using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MogobariWebAPI.Helper;
using MogobariWebAPI.Models;
using MogobariWebAPI.BL.Interface;
using MogobariWebAPI.BL;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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



            #region JWT config
            var jwtSection = Configuration.GetSection("JWTSettings");
            services.Configure<JWTSettings>(jwtSection);

            //to validate the token which has been sent by clients
            var appSettings = jwtSection.Get<JWTSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                    //ClockSkew = TimeSpan.Zero
                };
            });
            #endregion

            #region Scoped
            services.AddScoped<IPictureManager, PictureManager>();
            services.AddScoped<ICustomerManager, CustomerManager>();
            services.AddScoped<ITokenManager, TokenManager>();
            #endregion

            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("EliasHridoy", new OpenApiInfo { Title = "MogoBari API", Version = "v1" });
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
            app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/EliasHridoy/swagger.json", "MogoBari Api"));


            //app.UseSwaggerUI(ui =>
            //{
            //    ui.SwaggerEndpoint("/swagger/EliasHridoy/swagger.json", "MogoBari API Endpoint");
            //});

            app.UseMvc();
        }
    }
}
