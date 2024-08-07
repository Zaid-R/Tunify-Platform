﻿using Microsoft.EntityFrameworkCore;
using TunifyPrj.Data;
using TunifyPrj.Models;
using TunifyPrj.Repositories.Interfaces;

namespace TunifyPrj.Repositories.Services
{
    public class ArtistService : IArtist
    {
        private readonly TunifyContext _context;

        public ArtistService(TunifyContext context)
        {
            _context = context;
        }

        public async Task<List<Artist>> GetAllAsync()
        {
            var allArtists = await _context.Artists.ToListAsync();
            return allArtists;
        }

        public async Task<Artist> GetByIdAsync(int artistId) => await _context.Artists.FindAsync(artistId);

        public async Task<Artist> InsertAsync(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<Artist> UpdateAsync(int id,Artist artist)
        {
            var exsitingEmployee = await _context.Artists.FindAsync(id);
            exsitingEmployee = artist;
            await _context.SaveChangesAsync();
            return artist;
        }

        public async Task<Artist> DeleteAsync(int id)
        {
            var artist = await GetByIdAsync(id);
            _context.Entry(artist).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return artist;
        }
    }

}