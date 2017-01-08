using Api.Data;
using Exceptionless;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


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
            var connection = @"data source=169.50.111.5,781;initial catalog=nialljt1_GroupBookings;Uid=nialljt1_nialljt1;password=zxTx93@2;MultipleActiveResultSets=True;";
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

            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "http://localhost/IdentityServer2",
                ScopeName = "api1",

                RequireHttpsMetadata = false
            });

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUi("swagger/ui", "/gb/swagger/v1/swagger.json");
            app.UseExceptionless("d8YPf5iMRQYRRu6n909GlWfNDaUd2eFWD40GSmho");
        }
    }
}
