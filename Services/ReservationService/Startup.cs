using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ReservationService.AsyncDataServices;
using ReservationService.AsyncEventProcessing.MessageSubscriber;
using ReservationService.AsyncEventProcessing;
using ReservationService.Repositories;
using ReservationService.Context;
using System.Text.Json.Serialization;

namespace ReservationService
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
            services.AddCors(options => options.AddPolicy("ReservationCorsPolicy", build =>
            {
                build.WithOrigins("http://localhost:8080")
                     .AllowAnyMethod()
                     .AllowAnyHeader();
            }));

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSingleton<IEventProcessor, EventProcessor>();

            services.AddSingleton<IMessageBusClient, MessageBusClient>();

            services.AddHostedService<MessageBusSubscriber>();

            var server = Configuration["DB_SERVER"] ?? "localhost";
            var port = Configuration["DB_PORT"] ?? "1433";
            var user = Configuration["DB_USER"] ?? "sa";
            var password = Configuration["DB_PASSWORD"] ?? "yourStrong(!)Password";
            var service = Configuration["SERVICE_NAME"] ?? "Reservation";

            services.AddDbContext<ReservationContext>(options =>
            {
                options.EnableSensitiveDataLogging();
                options.UseSqlServer(
                   $"Data Source={server},{port};Initial Catalog={service};User Id={user};Password={password}",
                   a => a.MigrationsAssembly(typeof(ReservationContext).Assembly.FullName));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reservation", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReservationService v1"));

            app.UseCors("ReservationCorsPolicy");

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
