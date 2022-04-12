using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;
using MusicPlayer.Models;
using MusicPlayer.ViewModels;
using System.Collections.Generic;
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










    }
}
