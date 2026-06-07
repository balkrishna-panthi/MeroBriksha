using MeroBriksha.Services.Services;
using MeroBriksha.Services.Interfaces;
using Microsoft.OpenApi;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MeroBriksha.Data.DBContext;
using MeroBriksha.Data.Interfaces;
using MeroBriksha.Data.Repositories;

namespace MeroBriksha
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

                builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MeroBriksha API",
                    Description = "API for MeroBriksha"
                });
            });
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            #region DI
            builder.Services.AddTransient<IPlantService, PlantService>();
            builder.Services.AddScoped<IPlantRepository, PlantRepository>();

            builder.Services.AddScoped<IDonorRepository, DonorRepository>();
            builder.Services.AddScoped<IDonorService, DonorService>();
            #endregion

            var app = builder.Build();
            try
            {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

           

            app.MapControllers();
            }
            catch (ReflectionTypeLoadException ex)
            {
                Console.WriteLine("ReflectionTypeLoadException occurred:");

                foreach (var loaderException in ex.LoaderExceptions)
                {
                    Console.WriteLine(loaderException?.Message);
                }

                throw;
            }

            app.Run();
        }
    }
}