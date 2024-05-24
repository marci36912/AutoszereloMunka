
using Autoszerelo.Database;
using Autoszerelo.Services;
using Microsoft.EntityFrameworkCore;


namespace Autoszerelo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

            builder.Services.AddSingleton<IUgyfelService, UgyfelService>();
            builder.Services.AddSingleton<IMunkaService, MunkaService>();

            var app = builder.Build();

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
