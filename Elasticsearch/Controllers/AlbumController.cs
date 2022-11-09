using System;
using Microsoft.AspNetCore.Mvc;
using Elasticsearch.Models;
using Elasticsearch.Services;

namespace Elasticsearch.Controllers
{
    /// <summary>
    /// AlbumController
    /// </summary>
    public class AlbumController : Controller
    {
        private readonly AlbumService albumService;

        /// <summary>
        /// Constructor
        /// Initialize albums service
        /// </summary>
        /// <param name="albumService">Albums service</param>
        public AlbumController(AlbumService albumService)
        {
            this.albumService = albumService;
        }

        /// <summary>
        /// View all albums
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index() => View(albumService.GetAll());

        public IActionResult New() => View();
    }
}