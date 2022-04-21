using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;
using MusicPlayer.Models;
using MusicPlayer.ViewModels;
using System.Collections.Generic;
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
        public async Task<IActionResult> MyMusic()
        {
            var user = await db.User.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);

            var mySongs =
                from list in db.SongList
                join song in db.Song on list.SongId equals song.Id
                join author in db.Author on song.AuthorId equals author.Id
                where list.UserId == user.Id
                select new SongViewModel
                {
                    Id = song.Id,
                    Name = song.Name,
                    Author = author.Name,
                    FilePath = song.FilePath,
                    CoverPath = song.CoverPath
                };

            ViewBag.playlists = new SelectList(db.Playlist, "Id", "Name");
            return View(await mySongs.ToListAsync());

        }


        public async Task<IActionResult> AddToPlaylist(int SongId, int PlaylistId)
        {
            var spl = db.SongsPlaylist.FirstOrDefault(x => x.SongId == SongId && x.PlaylistId == PlaylistId);
            if (spl == null)
            {
                db.SongsPlaylist.Add(new SongsPlaylist { SongId = SongId, PlaylistId = PlaylistId });
                await db.SaveChangesAsync();
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
