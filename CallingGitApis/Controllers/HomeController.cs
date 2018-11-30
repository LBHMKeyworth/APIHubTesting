using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CallingGitApis.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using CallingGitApis.Models;

namespace CallingGitApis.Controllers
{
    public class HomeController : Controller
    {
        static HttpClient client = new HttpClient();
        public async Task<IActionResult> Index()
        {
            
            List<Repository> repos = await GitRepo.GetReposAsync();
            return View(repos);
        }
        

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
