using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicPlayer.Data;

namespace MusicPlayer.Controllers
{
    public class AlbumsController : Controller
    {
        ApplicationDbContext db;
        public AlbumsController(ApplicationDbContext context)
        {
            db = context;
        }


        [Authorize(Roles = "admin, user")]
        public IActionResult Albums(string album, string author)
        {

            return View();
        }
    }
}
