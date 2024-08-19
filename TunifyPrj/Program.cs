
using Microsoft.EntityFrameworkCore;
using TunifyPrj.Data;
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

            builder.Services.AddScoped<IUser, UserService>();
            builder.Services.AddScoped<IArtist, ArtistService>();
            builder.Services.AddScoped<IPlaylist, PlaylistService>();
            builder.Services.AddScoped<ISong, SongService>();
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

            app.Run();


        }
    }
}
