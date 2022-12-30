using FlightService.AsyncDataServices;
using FlightService.AsyncEventProcessing;
using FlightService.AsyncEventProcessing.MessageSubscriber;
using FlightService.Context;
using FlightService.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;

namespace FlightService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("FlightCorsPolicy", build =>
            {
                build.WithOrigins("http://localhost:8080")
                     .AllowAnyMethod()
                     .AllowAnyHeader();
            }));

            services.AddControllers();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSingleton<IEventProcessor, EventProcessor>();

            services.AddSingleton<IMessageBusClient, MessageBusClient>();

            services.AddHostedService<MessageBusSubscriber>();

            var server = Configuration["DB_SERVER"] ?? "localhost";
            var port = Configuration["DB_PORT"] ?? "1433";
            var user = Configuration["DB_USER"] ?? "sa";
            var password = Configuration["DB_PASSWORD"] ?? "yourStrong(!)Password";
            var service = Configuration["SERVICE_NAME"] ?? "Flight";

            services.AddDbContext<FlightContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(
                   $"Data Source={server},{port};Initial Catalog={service};User Id={user};Password={password}",
                   a => a.MigrationsAssembly(typeof(FlightContext).Assembly.FullName));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Flight", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flight v1"));

            app.UseHttpsRedirection();

            app.UseCors("FlightCorsPolicy");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
