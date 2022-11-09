using System;
using Microsoft.AspNetCore.Mvc;
using Elasticsearch.Models;
using Elasticsearch.Services;

namespace Elasticsearch.Controllers
{
    /// <summary>
    /// ArtistController
    /// </summary>
    public class ArtistController : Controller
    {
        private readonly ArtistService artistService;

        /// <summary>
        /// Constructor
        /// Initialize Artists service
        /// </summary>
        /// <param name="artistService">Artists service</param>
        public ArtistController(ArtistService artistService)
        {
            this.artistService = artistService;
        }

        /// <summary>
        /// Get all artists
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index() => View(artistService.GetAll());
    }
}