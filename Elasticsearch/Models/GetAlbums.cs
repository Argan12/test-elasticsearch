using System;
using System.Collections.Generic;

#nullable disable

namespace Elasticsearch.Models
{
    public partial class GetAlbums
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Year { get; set; }
        public string Genres { get; set; }
    }
}