
using Autoszerelo.Database;
using Autoszerelo.Services;
using Autoszerelo.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Serilog;


namespace Autoszerelo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(
                x =>
                {
                    x.AddPolicy("AllowLocalhost",
                    y=> y.WithOrigins("https://localhost:7003", "http://localhost:5062", "https://localhost:7101", "http://localhost:5192")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .SetPreflightMaxAge(TimeSpan.FromDays(5)));
                });

            builder.Services.AddSerilog(
                    config =>
                        config
                            .MinimumLevel.Information()
                            .WriteTo.Console()
                            .WriteTo.File("log.txt"));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AutoszereloDbContext>(options =>
            {
                string conncetion = builder.Configuration.GetConnectionString("AutoszereloDbConnection");
                options.UseMySql(conncetion, ServerVersion.AutoDetect(conncetion));
                options.UseLazyLoadingProxies();
            }, ServiceLifetime.Singleton);

            builder.Services.AddControllers(options =>
            options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

            builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            builder.Services.AddSingleton<IUgyfelService, UgyfelService>();
            builder.Services.AddSingleton<IMunkaService, MunkaService>();

            var app = builder.Build();

            app.UseRouting();
            app.UseCors("AllowLocalhost");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
