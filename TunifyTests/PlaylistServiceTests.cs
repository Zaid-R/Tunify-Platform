using Microsoft.EntityFrameworkCore;
using Moq;
using TunifyPrj.Data;
using TunifyPrj.Models;
using TunifyPrj.Repositories.Services;

namespace TunifyTests
{
    public class PlaylistServiceTests
    {
        [Fact]
        public async Task GetSongsInPlaylistAsync_ShouldReturnCorrectSongs()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<TunifyContext>()
                .UseInMemoryDatabase(databaseName: "TunifyTestDatabase")
                .Options;

            using (var context = new TunifyContext(options))
            {
                context.Playlists.Add(new Playlist
                {
                    PlaylistID = 1,
                    PlaylistName = "My Playlist",
                    PlaylistSongs = new List<PlaylistSong>
                {
                    new PlaylistSong
                    {
                        Song = new Song
                        {
                            SongID = 1,
                            Title = "Song 1",
                            Artist = new Artist
                            {
                                ArtistID = 1,
                                Name = "Artist 1",
                                Bio = "Bio of Artist 1", // Ensure Bio is set
                            },
                            Album = new Album
                            {
                                AlbumID = 1,
                                AlbumName = "Album 1"
                            },
                            Duration = new TimeSpan(0, 3, 45),
                            Genre = "Pop"
                        }
                    },
                    new PlaylistSong
                    {
                        Song = new Song
                        {
                            SongID = 2,
                            Title = "Song 2",
                            Artist = new Artist
                            {
                                ArtistID = 2,
                                Name = "Artist 2",
                                Bio = "Bio of Artist 2", // Ensure Bio is set
                            },
                            Album = new Album
                            {
                                AlbumID = 2,
                                AlbumName = "Album 2"
                            },
                            Duration = new TimeSpan(0, 4, 20),
                            Genre = "Rock"
                        }
                    }
                }
                });

                await context.SaveChangesAsync();
            }

            using (var context = new TunifyContext(options))
            {
                var service = new PlaylistService(context);

                // Act
                var songs = await service.GetSongsInPlaylistAsync(1);

                // Assert
                Assert.Equal(2, songs.Count());
                Assert.Contains(songs, s => s.Title == "Song 1");
                Assert.Contains(songs, s => s.Title == "Song 2");
            }
        }
    }
}