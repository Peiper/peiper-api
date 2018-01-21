using api.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            var connectionString = Configuration.GetConnectionString("DbContext");
            services.AddEntityFrameworkNpgsql().AddDbContext<DbPsqlContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<DbContext, DbPsqlContext>();
            services.AddScoped<ITestRepository, TestRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var origin = env.IsDevelopment() ? "http://localhost:9000" : "https://peiper.se";
            app.UseCors(builder =>
                builder.WithOrigins(origin));

            app.UseMvc();
        }
    }
}
