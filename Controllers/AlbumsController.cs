using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;
using MusicPlayer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlayer.Controllers
{
    public class AlbumsController : Controller
    {
        ApplicationDbContext db;
        public AlbumsController(ApplicationDbContext context)
        {
            db = context;
        }

        [AllowAnonymous]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> Albums(string album, string author)
        {
            var res = await db.Album.Include(s => s.Songs).ThenInclude(a => a.Author).ToListAsync();







            return View(res);
        }
    }
}
