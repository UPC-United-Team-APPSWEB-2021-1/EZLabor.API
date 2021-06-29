using EZLabor.API.Domain.Persistence.Contexts;
using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.Domain.Services;
using EZLabor.API.Percistence.Repositories;
using EZLabor.API.Services;
using EZLabor.API.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZLabor.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        ///
        
        
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();

        //    var appSettingsSection = Configuration.GetSection("AppSettings");
        //    services.Configure<AppSettings>(appSettingsSection);

        //    var appSettings = appSettingsSection.Get<AppSettings>();
        //    var key = Encoding.ASCII.GetBytes(appSettings.Secret);

        //    services.AddAuthentication(x =>
        //    {
        //        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    })
        //        .AddJwtBearer(x =>
        //        {
        //            x.RequireHttpsMetadata = false;
        //            x.SaveToken = true;
        //            x.TokenValidationParameters = new TokenValidationParameters
        //            {
        //                ValidateIssuerSigningKey = true,
        //                IssuerSigningKey = new SymmetricSecurityKey(key),
        //                ValidateIssuer = false,
        //                ValidateAudience = false
        //            };
        //        });

        //}

        // DbContext Configuration
        services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Dependency Injection Configuration
            services.AddScoped<IFreelancerRepository, FreelancerRepository>();
            services.AddScoped<IEmployerRepository, EmployerRepository>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IProposalRepository, ProposalRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IFreelancerService, FreelancerService>();
            services.AddScoped<IEmployerService, EmployerService>();
            services.AddScoped<ISkillService, SkillService>();
            services.AddScoped<IProposalService, ProposalService>();

            // Endpoints Case Conventions Configuration

            services.AddRouting(options => options.LowercaseUrls = true);

            // AutoMapper initialization
            services.AddAutoMapper(typeof(Startup));

            // Documentation Setup
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EZLabor.API", Version = "v1" });
                c.EnableAnnotations();
            });
        }



        ///

        /*  
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EZLabor.API", Version = "v1" });
            });
        }*/

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EZLabor.API v1"));
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
