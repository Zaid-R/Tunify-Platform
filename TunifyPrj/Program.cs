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
            //string ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

            //builder.Services.AddDbContext<TunifyContext>(optionsX => optionsX.UseSqlServer(ConnectionString));


            builder.Services.AddScoped<IUser, UserService>();
            builder.Services.AddScoped<IArtist, ArtistService>();
            builder.Services.AddScoped<IPlaylist, PlaylistService>();
            builder.Services.AddScoped<ISong, SongService>();
            var app = builder.Build();
            app.MapControllers();
            app.MapGet("/", () => "Hello World!");

            app.Run();


        }
    }
}
