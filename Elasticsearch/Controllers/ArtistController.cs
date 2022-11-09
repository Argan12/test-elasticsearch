using System;
using Microsoft.AspNetCore.Mvc;
using Elasticsearch.Models;
using Elasticsearch.Services;

namespace Elasticsearch.Controllers
{
    public class ArtistController : Controller
    {
        private readonly ArtistService artistService;

        public ArtistController(ArtistService artistService)
        {
            this.artistService = artistService;
        }

        public IActionResult Index() => View(artistService.GetAll());
    }
}