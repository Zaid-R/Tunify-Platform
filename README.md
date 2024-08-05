# Tunify Web App

## Introduction

Welcome to **Tunify**, a comprehensive web application designed to enhance your music experience. Tunify allows users to explore a vast collection of songs, create personalized playlists, and manage subscriptions. Whether you're an artist looking to share your music or a listener seeking new tunes, Tunify provides a seamless and engaging platform for all your musical needs.

### Entity Relationship Diagram (ERD)

![ERD](./images/TunifyERD.png)

Below is a simplified representation of the relationships between the entities:


### Detailed Relationships

- **User and Subscription**: Each user subscribes to a specific subscription plan, which determines their access level and features within the app.
- **User and Playlist**: Users can create multiple playlists, each containing a collection of songs.
- **Artist and Album**: Artists can release multiple albums, each containing several songs.
- **Artist and Song**: Artists can produce multiple songs, which may be part of different albums.
- **Album and Song**: Each album consists of multiple songs, and each song belongs to a specific album.
- **Playlist and PlaylistSong**: Playlists are collections of songs, managed through the PlaylistSong entity, which links songs to playlists.

## Overview of Entity Relationships

Tunify's database is structured to efficiently manage and relate various entities such as Users, Artists, Albums, Songs, Playlists, and Subscriptions. Below is an overview of the relationships between these entities:

### Entities and Their Relationships

1. **User**
    - **Attributes**: UserID, Username, Email, JoinDate, SubscriptionID
    - **Relationships**:
        - A User has one Subscription.
        - A User can have multiple Playlists.

2. **Subscription**
    - **Attributes**: SubscriptionID, SubscriptionType, Price
    - **Relationships**:
        - A Subscription can have multiple Users.

3. **Artist**
    - **Attributes**: ArtistID, Name, Bio
    - **Relationships**:
        - An Artist can have multiple Albums.
        - An Artist can have multiple Songs.

4. **Album**
    - **Attributes**: AlbumID, AlbumName, ReleaseDate, ArtistID
    - **Relationships**:
        - An Album belongs to one Artist.
        - An Album can have multiple Songs.

5. **Song**
    - **Attributes**: SongID, Title, ArtistID, AlbumID, Duration, Genre
    - **Relationships**:
        - A Song belongs to one Artist.
        - A Song belongs to one Album.
        - A Song can be part of multiple PlaylistSongs.

6. **Playlist**
    - **Attributes**: PlaylistID, UserID, PlaylistName, CreatedDate
    - **Relationships**:
        - A Playlist belongs to one User.
        - A Playlist can have multiple PlaylistSongs.

7. **PlaylistSong**
    - **Attributes**: PlaylistSongID, PlaylistID, SongID
    - **Relationships**:
        - A PlaylistSong belongs to one Playlist.
        - A PlaylistSong belongs to one Song.


## Getting Started

To get started with Tunify, follow these steps:

1. **Clone the Repository**: `git clone https://github.com/yourusername/tunify.git`
2. **Navigate to the Project Directory**: `cd tunify`
3. **Set Up the Database**: Ensure you have a SQL Server instance running and update the connection string in `appsettings.json`.
4. **Run the Application**: Use your preferred IDE to build and run the application.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

