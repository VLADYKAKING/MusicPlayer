using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;
using MusicPlayer.Models;
using MusicPlayer.ViewModels;
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


        //all songs to view
        [AllowAnonymous]
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> AllSongs(int? genre, string name)
        {

            var res = db.Song.Join(
                db.Author,
                s => s.AuthorId,
                a => a.Id,
                (s, a) => new SongViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Author = a.Name,
                    FilePath = s.FilePath,
                    CoverPath = s.CoverPath,
                    GenreId = s.GenreId,
                });
            if (genre != null && genre != 0)
            {
                res = res.Where(p => p.GenreId == genre);
            }
            if (!String.IsNullOrEmpty(name))
            {
                res = res.Where(x => x.Name.Contains(name));
            }
            var genres = db.Genre.ToList();
            genres.Insert(0, new Genre { Id = 0, Name = "Все" });

            ViewBag.genres = new SelectList(genres, "Id", "Name");
            return View(await res.ToListAsync());
        }


        //add to db
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


        //error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
