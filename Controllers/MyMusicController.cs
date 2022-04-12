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
    public class MyMusicController : Controller
    {
        private ApplicationDbContext db;
        public MyMusicController(ApplicationDbContext context)
        {
            db = context;
        }


        //my music
        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> MySongs()
        {
            //return View(await
            //    db.Song.Join(
            //    db.Author,
            //    author => author.AuthorId,
            //    a => a.Id,
            //    (s, a) => new SongViewModel
            //    {
            //        Id = s.Id,
            //        Name = s.Name,
            //        Author = a.Name,
            //        FilePath = s.FilePath,
            //        CoverPath = s.CoverPath
            //    }).ToListAsync());
            return View(await
                db.SongList.
                )
        }










    }
}
