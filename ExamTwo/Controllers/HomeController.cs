using System.Diagnostics;
using Examtwo.Models;
using Examtwo.Core;
using Microsoft.AspNetCore.Mvc;

namespace Examtwo.Controllers
{
    public class HomeController : Controller
    {
        private readonly Database _database;
        public HomeController(Database database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            var exams = _database.Exams.ToList();
            return View(exams);
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