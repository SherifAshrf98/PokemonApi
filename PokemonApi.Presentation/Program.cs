
using Microsoft.EntityFrameworkCore;
using PokemonApi.Application.Interfaces;
using PokemonApi.Application.Services;
using PokemonApi.Infrastructure.Data;
using PokemonApi.Infrastructure.Interfaces;
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
