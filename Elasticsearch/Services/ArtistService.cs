using Elasticsearch.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Elasticsearch.Services
{
    /// <summary>
    /// Service Artist
    /// Contains methods about artists
    /// </summary>
    public class ArtistService
    {
        private readonly ElasticsearchContext _context;

        /// <summary>
        /// Constructor
        /// Initialize DbContext
        /// </summary>
        /// <param name="context">DbContext</param>
        public ArtistService(ElasticsearchContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all artists
        /// </summary>
        /// <returns>Artists</returns>
        public List<Artist> GetAll()
        {
            try
            {
                return _context
                    .Artists
                    .OrderBy(a => a.Name)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("An error occurred while retrieving artists.", e);
            }
        }

        /// <summary>
        /// Show artist details
        /// </summary>
        /// <param name="id">Artist ID</param>
        /// <returns>Artist</returns>
        public Artist GetDetails(int id)
        {
            try
            {
                return _context.Artists.FirstOrDefault(a => a.Id == id);
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("An error occurred while getting artist details.", e);
            }
        }

        /// <summary>
        /// Add new artist
        /// </summary>
        /// <param name="artist">Artist</param>
        public void New(Artist artist)
        {
            try
            {
                _context.Artists.Add(artist);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DbUpdateException("An error occurred while adding new artist.", e);
            }
        }

        /// <summary>
        /// Editing an artist
        /// </summary>
        /// <param name="artist">Artist</param>
        public void Edit(Artist artist)
        {
            try
            {
                Artist _artist = _context.Artists.FirstOrDefault(a => a.Id == artist.Id);

                _artist.Name = artist.Name;
                _artist.Description = artist.Description;
                _artist.Genres = artist.Genres;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DbUpdateException("An error occurred while editing an artist.", e);
            }
        }

        /// <summary>
        /// Delete an artist
        /// </summary>
        /// <param name="id">Artist id</param>
        public void Remove(int id)
        {
            try
            {
                // First step : remove all albums produced by the artist
                List<Album> albums = _context.Albums
                    .Where(a => a.Artist == id)
                    .ToList();
                _context.Albums.RemoveRange(albums);

                // Second step : remove artist
                Artist artist = _context.Artists.FirstOrDefault(a => a.Id == id);
                _context.Artists.Remove(artist);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DbUpdateException("An error occurred while removing an artist.", e);
            }
        }
    }
}