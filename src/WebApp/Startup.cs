using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using System;
using WebApp.Data;
using WebApp.Services;
using WebApp.Utils;

namespace WebApp
{
    public class Startup
    {
        /*
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }*/

        public Startup(IWebHostEnvironment env)
        {
            System.Diagnostics.Debug.WriteLine(env.EnvironmentName);
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddDbContext<UserContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("VisualDijkstraConn")));

            //JSON serializer
            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
                .Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                = new DefaultContractResolver()
                );

            services.AddControllers();

            // UserRepository is a type of IUserRepository 
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGraphRepository, GraphRepository>();
            services.AddScoped<IVerificationRepository, VerificationRepository>();
            services.AddScoped<JwtService>();

            //loading settings from appsettings
            services.Configure<JwtOptions>(Configuration.GetSection("JwtConfig"));

            //loading smtp config
            services.AddScoped<IEmailHandler, EmailHandler>((serviceProvider) =>
            {
                IConfiguration config = serviceProvider.GetRequiredService<IConfiguration>();

                return new EmailHandler(
                    config.GetValue<String>("EmailConfig:Host"),
                    config.GetValue<int>("EmailConfig:Port"),
                    config.GetValue<String>("EmailConfig:SmtpUsername"),
                    config.GetValue<String>("EmailConfig:SmtpPassword"),
                    config.GetValue<String>("EmailConfig:SenderEmail"),
                    config.GetValue<String>("EmailConfig:SenderName")
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
