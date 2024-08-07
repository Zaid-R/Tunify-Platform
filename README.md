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

## Repository Design Pattern

### What is the Repository Design Pattern?

The **Repository Design Pattern** is a design pattern that mediates data from and to the database using collections of objects. It provides a more object-oriented way to access and manipulate data, abstracting the data access layer from the business logic layer.

### Benefits of the Repository Design Pattern

- **Separation of Concerns**: By separating the data access logic from the business logic, the Repository Design Pattern helps to keep the codebase clean and maintainable.
- **Testability**: It becomes easier to mock repositories for unit testing, which improves the testability of the application.
- **Flexibility**: Allows for easy swapping of data sources without changing the business logic. For example, you can switch from a SQL database to a NoSQL database with minimal changes.
- **Centralized Data Access Logic**: All data access logic is contained in one place, making it easier to manage and update.
- **Reusability**: Common data access code can be reused across different parts of the application.

### Implementation in Tunify

In the Tunify Web App, repositories are used to handle the data access for various entities such as Users, Artists, Albums, Songs, Playlists, and Subscriptions. Each repository provides methods to perform CRUD operations and abstracts the underlying database interactions.

For example:

```csharp
public interface IUser
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(int userId);
    Task<User> InsertAsync(User user);
    Task<User> UpdateAsync(int id,User user);
    Task<User> DeleteAsync(int userId);
}
```
