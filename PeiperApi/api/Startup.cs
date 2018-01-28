using api.Application;
using api.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeiperApi.Domain.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace api
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
            services.AddMvc();
            services.AddCors();

            services.Configure<DbSettings>(Configuration.GetSection("DbSettings"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Peiper API", Version = "v1" });
            });

            services.AddScoped<DbContext, DbPsqlContext>();
            services.AddScoped<IDeployRepository, DeployRepository>();
            services.AddScoped<IDeployApplication, DeployApplication>();

            services.AddEntityFrameworkNpgsql().AddDbContext<DbPsqlContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Peiper API V1");
            });

            var origin = env.IsDevelopment() ? "http://localhost:9000" : "https://peiper.se";
            app.UseCors(builder =>
                builder.WithOrigins(origin));

            app.UseMvc();
        }
    }
}
