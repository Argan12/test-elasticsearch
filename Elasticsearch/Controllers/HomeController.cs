using System;
using Microsoft.AspNetCore.Mvc;
using Elasticsearch.Models;
using Elasticsearch.Services;

namespace Elasticsearch.Controllers
{
    public class HomeController : Controller
    {
        public readonly ArtistService artistService;

        public HomeController(ArtistService artistService)
        {
            this.artistService = artistService;
        }

        public IActionResult Index()
        {
            return View(artistService.GetAll());
        }
    }
}
