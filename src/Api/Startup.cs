﻿using Api.Data;
using Exceptionless;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("GroupBookingsDatabase");
            services.AddDbContext<Api.AppContext>(options => options.UseSqlServer(connection));

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost")
                        .AllowAnyHeader()
                        .AllowAnyMethod();

                    policy.WithOrigins("http://localhost/gb")
                   .AllowAnyHeader()
                   .AllowAnyMethod();

                    policy.WithOrigins("http://127.0.0.1:8080")
                    .AllowAnyHeader()
                    .AllowAnyMethod();

                    policy.WithOrigins("http://169.50.111.5")
                    .AllowAnyHeader()
                    .AllowAnyMethod();

                    policy.WithOrigins("http://www.groupbookit.com")
                    .AllowAnyHeader()
                    .AllowAnyMethod();

                    policy.WithOrigins("http://groupbookit.com")
                    .AllowAnyHeader()
                    .AllowAnyMethod();

                    policy.WithOrigins("http://127.0.0.1:8081")
                    .AllowAnyHeader()
                    .AllowAnyMethod();

                    policy.WithOrigins("http://169.50.111.5")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });

                ////// this defines a CORS policy called "default"
                ////options.AddPolicy("default1", policy =>
                ////{
                ////    policy.WithOrigins("http://localhost:5001")
                ////        .AllowAnyHeader()
                ////        .AllowAnyMethod();
                ////});
            });

            services.AddMvcCore()
            .AddAuthorization()
            .AddJsonFormatters();

            services.AddLogging();
            services.AddSingleton<IBookingsRepository, BookingsRepository>();
            services.AddSingleton<IMenuRepository, MenuRepository>();
            services.AddSingleton<IDinersRepository, DinersRepository>();
            services.AddSingleton<IDinerMenuItemsRepository, DinerMenuItemsRepository>();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            app.UseCors("default");
            app.UseApplicationInsightsRequestTelemetry();
            app.UseApplicationInsightsExceptionTelemetry();

            var identityServerAuthority = Configuration.GetSection("ApplicationSettings").GetChildren().First(o => o.Key == "IdentityServerAuthority").Value;

            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = identityServerAuthority,
                ScopeName = "api1",

                RequireHttpsMetadata = false
            });

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUi("swagger/ui", "/swagger/v1/swagger.json");
            app.UseExceptionless("d8YPf5iMRQYRRu6n909GlWfNDaUd2eFWD40GSmho");
        }
    }
}
