using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;
using MusicPlayer.Models;
using System;
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


        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> MyMusic(string name)
        {
            var user = await db.User.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);

            var res = db.SongList
                .Include(s => s.Song)
                .ThenInclude(a => a.Author)
                .Where(x => x.UserId == user.Id);
            if (!String.IsNullOrEmpty(name))
            {
                res = res.Where(x => x.Song.Name.ToLower().Contains(name.ToLower()));
            }

            ViewBag.playlists = new SelectList(db.Playlist, "Id", "Name");

            return View(await res.ToListAsync());
        }


        public async Task<IActionResult> AddToPlaylist(int SongId, int PlaylistId)
        {
            if(SongId>0 && PlaylistId > 0)
            {
                var spl = db.SongsPlaylist.FirstOrDefault(x => x.SongId == SongId && x.PlaylistId == PlaylistId);
                if (spl == null)
                {
                    db.SongsPlaylist.Add(new SongsPlaylist { SongId = SongId, PlaylistId = PlaylistId });
                    await db.SaveChangesAsync();
                }
            }
            return RedirectToAction("MyMusic");
        }


        public async Task<IActionResult> DeleteFromMyMusic(int songId)
        {
            var user = await db.User.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);
            var song = db.SongList.FirstOrDefault(x => x.SongId == songId && x.UserId == user.Id);
            if (song != null)
            {
                db.SongList.Remove(song);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("MyMusic");
        }
    }
}
