using System.Net;
using System;
using Microsoft.AspNetCore.Mvc;
using Elasticsearch.Models;
using Elasticsearch.Models.ViewModels;
using Elasticsearch.Services;
using System.Linq;

namespace Elasticsearch.Controllers
{
    /// <summary>
    /// AlbumController
    /// </summary>
    public class AlbumController : Controller
    {
        private readonly ElasticsearchContext _context;
        private readonly AlbumService _albumService;
        private readonly ArtistService _artistService;

        /// <summary>
        /// Constructor
        /// Initialize albums service
        /// </summary>
        /// <param name="context">DbContext</param>
        /// <param name="albumService">Albums service</param>
        /// <param name="artistService">Artists service</param>
        public AlbumController(ElasticsearchContext context, AlbumService albumService, ArtistService artistService)
        {
            _context = context;
            _albumService = albumService;
            _artistService = artistService;
        }

        /// <summary>
        /// View all albums
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index() => View(_albumService.GetAll());

        /// <summary>
        /// Show album details
        /// </summary>
        /// <param name="id">Album id</param>
        /// <returns>View</returns>
        public IActionResult Details(int id)
        {
            GetAlbums album = _albumService.GetAll()
                .FirstOrDefault(a => a.Id == id);

            return View(album);
        }

        /// <summary>
        /// Add new album form
        /// </summary>
        /// <returns>View</returns>
        public IActionResult New()
        {
            AlbumViewModel AVM = new AlbumViewModel
            {
                Artists = _artistService.GetAll()
            };
            return View(AVM);
        }

        /// <summary>
        /// Add new album
        /// </summary>
        /// <param name="album">Album</param>
        /// <returns>Redirection</returns>
        [HttpPost]
        public IActionResult New(Album album)
        {
            _albumService.New(album);
            return RedirectToAction("New");
        }

        /// <summary>
        /// Edit album
        /// </summary>
        /// <param name="id">Album id</param>
        /// <returns>View</returns>
        public IActionResult Edit(int id)
        {
            AlbumViewModel AVM = new AlbumViewModel
            {
                Artists = _artistService.GetAll(),
                Album = _context.Albums.FirstOrDefault(a => a.Id == id)
            };
            return View(AVM);
        }

        /// <summary>
        /// Editing an album
        /// </summary>
        /// <param name="id">Album id</param>
        /// <param name="Album">Album</param>
        /// <returns>View</returns>
        [HttpPost]
        public IActionResult Edit(int id, Album Album)
        {
            _albumService.Edit(Album, id);
            return RedirectToAction("Edit", new { id = id });
        }

        /// <summary>
        /// Remove an album
        /// </summary>
        /// <param name="id">Album id</param>
        /// <returns>Redirection</returns>
        public IActionResult Delete(int id)
        {
            _albumService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}