using System.IO;
using Elasticsearch.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Elasticsearch.Services
{
    public class AlbumService
    {
        private readonly ElasticsearchContext context;

        public AlbumService(ElasticsearchContext context)
        {
            this.context = context;
        }

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