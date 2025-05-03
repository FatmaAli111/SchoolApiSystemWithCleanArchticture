
using Microsoft.EntityFrameworkCore;
using School.Core;
using School.Data.Entities;
using School.Infrastructure;
using School.Infrastructure.Data;
using School.Service;
using System;
using School.Core.Features.Students.Mapping;

namespace SchoolApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Add Dbcontext
            builder.Configuration.AddJsonFile("appsettings.json");
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection")));
            
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddInfrastructre(builder.Configuration);
            builder.Services.AddModuleServiceDependencies(builder.Configuration);
            builder.Services.AddCoreDependencies();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
