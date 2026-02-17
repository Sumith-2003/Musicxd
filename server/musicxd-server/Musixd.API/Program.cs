using Microsoft.EntityFrameworkCore;
using Musicxd.API.Services.Implementations;
using Musicxd.API.Services.Interfaces;
using Musicxd.Infrastructure.Data;
using Musicxd.Infrastructure.Repositories.Implementations;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Musicxd.API
{
    public class Program
    {
        public static async Task Main(string[] args) // Mark Main method as async and change return type to Task
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    sqlOptions => sqlOptions.MigrationsAssembly("Musicxd.API")
                );
            });

            // Add services to the container.
            builder.Services.AddScoped<ProfileService, ProfileService>();
            builder.Services.AddScoped<ProfileRepository, ProfileRepository>();
            builder.Services.AddScoped<IDataImportService, DataImportService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            //using (var scope = app.Services.CreateScope())
            //{
            //    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
            //    if (!dbContext.Artists.Any())
            //    {
            //        var importer = new ExcelImporter(dbContext);

            //        try
            //        {
            //            await importer.ImportArtistsFromExcelAsync("C:/your-path/data.xlsx"); 
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine("Excel import failed: " + ex.Message);
            //        }
            //    }
            //}

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            await app.RunAsync(); // Use RunAsync for consistency with async Main
        }
    }
}
