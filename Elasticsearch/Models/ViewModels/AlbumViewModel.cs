using Elasticsearch.Models;
using System.Collections.Generic;

namespace Elasticsearch.Models.ViewModels
{
    public class AlbumViewModel
    {
        public Album Album { get; set; }
        public List<Artist> Artists { get; set; }
    }
}