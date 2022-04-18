using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;
using MusicPlayer.Models;
using MusicPlayer.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlayer.Controllers
{
    public class PlayListsController : Controller
    {
        private ApplicationDbContext db;
        public PlayListsController(ApplicationDbContext context)
        {
            db = context;
        }


        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> PlayLists()
        {
            var user = await db.User.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);
            //var playlists =
            //    from pl in db.Playlist
            //    where pl.UserId == user.Id
            //    select new
            //    {
            //        Id = pl.Id,
            //        Name = pl.Name,
            //    };
            return View(await db.Playlist.Where(pl=>pl.UserId==user.Id).ToListAsync());
            //var res =
            //    from spl in db.SongsPlaylist
            //    join song in db.Song on spl.SongId equals song.Id
            //    join pl in db.Playlist on spl.PlaylistId equals pl.Id
            //    where pl.UserId == user.Id
            //    select new

        }





    }
}
