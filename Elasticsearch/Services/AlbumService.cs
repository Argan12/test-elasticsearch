using System.IO;
using Elasticsearch.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Elasticsearch.Services
{
    /// <summary>
    /// Service Albums
    /// Contains methods about albums
    /// </summary>
    public class AlbumService
    {
        private readonly ElasticsearchContext _context;

        /// <summary>
        /// Constructor
        /// Initialize DbContext
        /// </summary>
        /// <param name="context">DbContext</param>
        public AlbumService(ElasticsearchContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get all albums
        /// </summary>
        /// <returns>Stored procedure</returns>
        public List<GetAlbums> GetAll()
        {
            try
            {
                return _context.GetAlbums
                    .FromSqlRaw<GetAlbums>("EXEC GetAlbums")
                    .ToList();
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("An error occurred while retrieving albums.", e);
            }
        }

        /// <summary>
        /// Add new album
        /// </summary>
        /// <param name="album">Album</param>
        public void New(Album album)
        {
            try
            {
                _context.Add(album);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DbUpdateException("An error occurred during saving new album.", e);
            }
        }

        /// <summary>
        /// Edit album
        /// </summary>
        /// <param name="album">Album</param>
        /// <param name="id">Album Id</param>
        public void Edit(Album album, int id)
        {
            try
            {
                Album _album = _context.Albums.FirstOrDefault(a => a.Id == id);

                _album.Name = album.Name;
                _album.Artist = album.Artist;
                _album.Year = album.Year;
                _album.Genres = album.Genres;

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DbUpdateException("An error occurred while editing album.", e);
            }
        }

        /// <summary>
        /// Remove album
        /// </summary>
        /// <param name="id">Album id</param>
        public void Remove(int id)
        {
            try
            {
                Album album = _context.Albums.FirstOrDefault(a => a.Id == id);
                _context.Albums.Remove(album);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DbUpdateException("An error occurred while removing album.", e);
            }
        }
    }
}