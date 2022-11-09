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
        private readonly ElasticsearchContext context;

        /// <summary>
        /// Constructor
        /// Initialize DbContext
        /// </summary>
        /// <param name="context">DbContext</param>
        public AlbumService(ElasticsearchContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all albums
        /// </summary>
        /// <returns>Stored procedure</returns>
        public List<GetAlbums> GetAll()
        {
            try
            {
                return this.context.GetAlbums
                    .FromSqlRaw<GetAlbums>("EXEC GetAlbums")
                    .ToList();
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("An error occurred while retrieving albums.", e);
            }
        }
    }
}