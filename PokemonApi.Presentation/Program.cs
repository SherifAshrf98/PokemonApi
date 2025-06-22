
using PokemonApi.Application.Interfaces.Repositories;
using PokemonApi.Application.Interfaces.Services;
using PokemonApi.Infrastructure.Implementation.Services;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure.Data;
using PokemonApi.Presentation.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PokemonApi.Presentation.Helpers;
using System.Text;
using PokemonApi.Infrastructure.Implementation.Services.Security;

namespace PokemonApi.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();


            builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("jwtConfig"));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                var JwtConfig = builder.Configuration.GetSection("JwtConfig").Get<JwtConfig>();
                var key = Encoding.UTF8.GetBytes(JwtConfig.Key);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = JwtConfig.Issuer,
                    ValidAudience = JwtConfig.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero
                };

            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Register Application Services
            
            builder.Services.AddScoped<AuthService>();

            builder.Services.AddScoped<IPokemonService, PokemonService>();

            builder.Services.AddScoped<ICountryService, CountryService>();

            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddScoped<IOwnerService, OwnerService>();

            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

            }

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
