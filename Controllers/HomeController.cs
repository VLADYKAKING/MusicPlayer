using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;
using MusicPlayer.Models;
using MusicPlayer.ViewModels;
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
        public async Task<IActionResult> AllSongs()
        {
            return View(await
                db.Song.Join(
                db.Author,
                s => s.AuthorId,
                a => a.Id,
                (s, a) => new SongViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Author = a.Name,
                    FilePath = s.FilePath,
                    CoverPath = s.CoverPath
                }).ToListAsync());
        }


        //add to db
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> Add(int id)
        {
            var user = await db.User.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);
            if (await db.SongList.FirstOrDefaultAsync(x => x.SongId == id && x.UserId == user.Id) == null)
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
