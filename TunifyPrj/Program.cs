
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TunifyPrj.Data;
using TunifyPrj.Models;
using TunifyPrj.Repositories.Interfaces;
using TunifyPrj.Repositories.Services;

namespace TunifyPrj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

            builder.Services.AddIdentity<CustomUser, IdentityRole>()
                            .AddEntityFrameworkStores<TunifyContext>();

            builder.Services.AddDbContext<TunifyContext>(optionsX => optionsX.UseSqlServer(ConnectionString));
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Tunify API",
                    Version = "v1",
                    Description = "API for managing playlists, songs, and artists in the Tunify Platform"
                });
            });

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IAccount, AccountService>();
            builder.Services.AddScoped<IUser, UserService>();
            builder.Services.AddScoped<IArtist, ArtistService>();
            builder.Services.AddScoped<IPlaylist, PlaylistService>();
            builder.Services.AddScoped<ISong, SongService>();
            builder.Services.AddScoped<JwtTokenService>();

            // add auth service to the app using jwt
            builder.Services.AddAuthentication(
                options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
                ).AddJwtBearer(
                options =>
                {
                    options.TokenValidationParameters = JwtTokenService.ValidateToken(builder.Configuration);
                });

            var app = builder.Build();


            app.UseSwagger(
             options =>
             {
                 options.RouteTemplate = "/api/{documentName}/swagger.json";
             }
            );


            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Tunify API v1");
                options.RoutePrefix = "tunify";
            });
            app.MapControllers();
            app.MapGet("/", () => "Hello World!");
            app.UseAuthentication();
            app.UseAuthorization();

            app.Run();


        }
    }
}
