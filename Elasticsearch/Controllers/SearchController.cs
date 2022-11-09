using Elastic.Clients.Elasticsearch;
using Elastic.Transport;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Elasticsearch.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            var settings = new ElasticsearchClientSettings(new Uri("https://localhost:9200"))
                .CertificateFingerprint("C9:C1:DC:D9:FC:95:15:44:ED:EF:85:64:A4:9D:64:55:85:B5:D8:54:AC:30:CF:BA:A8:8F:57:D3:02:4E:D1:6A")
                .Authentication(new BasicAuthentication("elastic", "+D35OsbkvArfR6ZE_wyX"));

            var client = new ElasticsearchClient(settings);

            return View();
        }
    }
}