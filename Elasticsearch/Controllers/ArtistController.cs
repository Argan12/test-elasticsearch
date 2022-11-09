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
        private readonly ArtistService _artistService;

        /// <summary>
        /// Constructor
        /// Initialize Artists service
        /// </summary>
        /// <param name="artistService">Artists service</param>
        public ArtistController(ArtistService artistService)
        {
            _artistService = artistService;
        }

        /// <summary>
        /// Get all artists
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index() => View(_artistService.GetAll());

        /// <summary>
        /// Get artist details
        /// </summary>
        /// <param name="id">Artist ID</param>
        /// <returns>View</returns>
        public IActionResult Details(int id) => View(_artistService.GetDetails(id));

        /// <summary>
        /// Add new artist form
        /// </summary>
        /// <returns>View</returns>
        public IActionResult New() => View();

        /// <summary>
        /// Add new artist in db
        /// </summary>
        /// <param name="artist">Artist</param>
        /// <returns>Redirection</returns>
        [HttpPost]
        public IActionResult New(Artist artist)
        {
            _artistService.New(artist);
            return RedirectToAction("New");
        }

        /// <summary>
        /// Edit an artist form
        /// </summary>
        /// <param name="id">Artist id</param>
        /// <returns>View</returns>
        public IActionResult Edit(int id) => View(_artistService.GetDetails(id));

        /// <summary>
        /// Edit artist
        /// </summary>
        /// <param name="id">Artist id</param>
        /// <param name="artist">Artist</param>
        /// <returns>Redirection</returns>
        [HttpPost]
        public IActionResult Edit(int id, Artist artist)
        {
            _artistService.Edit(artist);
            return RedirectToAction("Edit", new { id = id });
        }

        /// <summary>
        /// Delete an artist
        /// </summary>
        /// <param name="id">Artist id</param>
        /// <returns>Redirection</returns>
        public IActionResult Delete(int id)
        {
            _artistService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}