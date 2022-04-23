using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;
using MusicPlayer.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlayer.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        public HomeController(ApplicationDbContext context)
        {
            db = context;
        }


        [AllowAnonymous]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> AllSongs(int? genre, string name, string author)
        {
            var res = await db.Song.Include(s => s.Author).Include(g => g.Genre).ToListAsync();

            if (genre != null && genre != 0)
            {
                res = res.Where(s => s.Genre.Id == genre).ToList();
            }
            if (!String.IsNullOrEmpty(name))
            {
                res = res.Where(s => s.Name.Contains(name)).ToList();
            }
            if (!String.IsNullOrEmpty(author))
            {
                res = res.Where(s => s.Author.Name.Contains(author)).ToList();
            }

            var genres = db.Genre.ToList();
            genres.Insert(0, new Genre { Id = 0, Name = "Все" });

            ViewBag.genres = new SelectList(genres, "Id", "Name");
            return View(res);
        }


        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> Add(int id)
        {
            var user = await db.User.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);
            var sl = await db.SongList.FirstOrDefaultAsync(x => x.SongId == id && x.UserId == user.Id);
            if (sl == null)
            {
                var songList = new SongList
                {
                    SongId = id,
                    UserId = user.Id
                };

                db.SongList.Add(songList);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("AllSongs");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
