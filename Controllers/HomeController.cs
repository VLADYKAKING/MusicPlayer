using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicPlayer.Data;
using MusicPlayer.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MusicPlayer.ViewModels;

namespace MusicPlayer.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            db = context;
        }
        [Authorize(Roles = "admin, user")]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await 
                db.Song.Join(
                db.Author,
                s => s.AuthorId,
                a => a.Id,
                (s, a) => new SongViewModel
                {
                    Name = s.Name,
                    Author = a.Name,
                    FilePath = s.FilePath,
                    CoverPath = s.CoverPath
                }).ToListAsync());
        }
        [Authorize(Roles = "admin")]
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
