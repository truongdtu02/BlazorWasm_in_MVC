using BlazorWasm_in_MVC.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWasm_in_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //[EnableCors]
        [HttpGet]
        public IActionResult Index(string id)
        {
            if(id != null)
            {
                return Redirect("/Home/DownFileFFmpeg/" + id);
            }
            return View();
        }

        public FileResult DownFileFFmpeg(string id)
        {
            string path = "wwwroot/FFmpegSrc/" + id;
            byte[] fileContent = System.IO.File.ReadAllBytes(path);
            return new FileContentResult(fileContent, "text/plan");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
