using Elasticsearch.Models;
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
        private readonly ElasticsearchContext context;

        /// <summary>
        /// Constructor
        /// Initialize DbContext
        /// </summary>
        /// <param name="context">DbContext</param>
        public ArtistService(ElasticsearchContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all artists
        /// </summary>
        /// <returns>Artists</returns>
        public List<Artist> GetAll()
        {
            try
            {
                return this.context.Artists.ToList();
            }
            catch (Exception e)
            {
                throw new ArgumentNullException("An error occurred while retrieving artists.", e);
            }
        }
    }
}