using EZLabor.API.Domain.Persistence.Contexts;
using EZLabor.API.Domain.Persistence.Repositories;
using EZLabor.API.Domain.Services;
using EZLabor.API.Percistence.Repositories;
using EZLabor.API.Services;
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

            services.AddControllers();

            // DbContext Configuration
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            // Dependency Injection Configuration
            services.AddScoped<IFreelancerRepository, FreelancerRepository>();
            services.AddScoped<IEmployerRepository, EmployerRepository>();
            services.AddScoped<IKnowledgeRepository, KnowledgeRepository>();
            services.AddScoped<IProposalRepository, ProposalRepository>();
            services.AddScoped<IFreelancerKnowledgeRepository, FreelancerKnowledgeRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IFreelancerService, FreelancerService>();
            services.AddScoped<IEmployerService, EmployerService>();
            services.AddScoped<IKnowledgeService, KnowledgeService>();
            services.AddScoped<IProposalRepository, ProposalRepository>();
            services.AddScoped<IFreelancerKnowledgeService, FreelancerKnowledgeService>();

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
