
using crudapi.Models;
using Microsoft.EntityFrameworkCore;

namespace crudapi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var provider=builder.Services.BuildServiceProvider();
            var config=provider.GetRequiredService<IConfiguration>();
            builder.Services.AddDbContext<StudentDBContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
