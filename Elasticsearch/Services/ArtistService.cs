using Elasticsearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Elasticsearch.Services
{
    public class ArtistService
    {
        private readonly ElasticsearchContext context;

        public ArtistService(ElasticsearchContext context)
        {
            this.context = context;
        }

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