using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;
using MusicPlayer.Models;
using System;
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
        public async Task<IActionResult> Albums(string albumName, string authorName)
        {
            var res = await db.Album.Include(s => s.Songs).ThenInclude(a => a.Author).ToListAsync();

            if (!String.IsNullOrEmpty(albumName))
            {
                res = res.Where(x => x.Name.ToLower().Contains(albumName.ToLower())).ToList();
            }
            if (!String.IsNullOrEmpty(authorName))
            {
                res = res.Where(x => x.Songs.FirstOrDefault().Author.Name.ToLower().Contains(authorName.ToLower())).ToList();
            }
            return View(res);
        }
    }
}
