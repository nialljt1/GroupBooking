// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using Api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

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

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"data source=DESKTOP-82VF481\SQLEXPRESS;initial catalog=GroupBookings;integrated security=True;MultipleActiveResultSets=True;";
            services.AddDbContext<AppContext>(options => options.UseSqlServer(connection));
            services.AddSingleton<IBookingsRepository, BookingsRepository>();
            services.AddCors(options=>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost")
                        .AllowAnyHeader()
                        .AllowAnyMethod();

                   //// policy.WithOrigins("http://localhost:5001")
                   ////.AllowAnyHeader()
                   ////.AllowAnyMethod();
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
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // this uses the policy called "default"
            app.UseCors("default");

            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "http://localhost/IdentityServer2",
                ScopeName = "api1",

                RequireHttpsMetadata = false
            });

            app.UseMvc();
        }
    }
}