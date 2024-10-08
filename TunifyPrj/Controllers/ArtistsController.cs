﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunifyPrj.Data;
using TunifyPrj.Models;
using TunifyPrj.Repositories.Interfaces;
using TunifyPrj.Repositories.Services;

namespace TunifyPrj.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly IArtist _artist;
        private readonly ISong _song;
        public ArtistsController(IArtist Artist,ISong song)
        {
            _artist = Artist;
            _song = song;
        }
        

        // GET: api/Artists
        [Route("/artists/getAll")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return await _artist.GetAllAsync();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            return await _artist.GetByIdAsync(id);
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist Artist)
        {
            var updateArtist = await _artist.UpdateAsync(id, Artist);
            return Ok(updateArtist);
        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist Artist)
        {
            var newArtist = await _artist.InsertAsync(Artist);
            return Ok(newArtist);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var deletedEmployee = _artist.DeleteAsync(id);
            return Ok(deletedEmployee);
        }


        [HttpPost("{artistId}/songs/{songId}")]
        public async Task<IActionResult> AddSongToArtist(int artistId, int songId)
        {
            await _artist.AddSongToArtistAsync(artistId, songId);
            return Ok();
        }

        [HttpGet("{artistId}/songs")]
        public async Task<IActionResult> GetSongsByArtist(int artistId)
        {
            var songs = await _artist.GetSongsByArtistAsync(artistId);
            return Ok(songs);
        }

    }
}
