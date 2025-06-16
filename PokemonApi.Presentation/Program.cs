
using PokemonApi.Application.Interfaces.Repositories;
using PokemonApi.Application.Interfaces.Services;
using PokemonApi.Infrastructure.Implementation.Services;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure.Data;
using PokemonApi.Presentation.Middlewares;

namespace PokemonApi.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IPokemonService, PokemonService>();

            builder.Services.AddScoped<ICountryService, CountryService>();

            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddScoped<IOwnerService, OwnerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
