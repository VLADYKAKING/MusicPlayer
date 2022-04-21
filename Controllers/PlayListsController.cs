﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;
using MusicPlayer.Models;
using MusicPlayer.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlayer.Controllers
{
    public class PlayListsController : Controller
    {
        ApplicationDbContext db;
        public PlayListsController(ApplicationDbContext context)
        {
            db = context;
        }


        [Authorize(Roles = "admin, user")]
        public async Task<IActionResult> PlayLists()
        {
            var user = await db.User.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);
            var res =
                from pl in db.Playlist
                where pl.UserId == user.Id
                select new PlayListsViewModel
                {
                    Playlist = pl,
                    ListSongViewModel = (from spl in db.SongsPlaylist
                                         join s in db.Song on spl.SongId equals s.Id
                                         join a in db.Author on s.AuthorId equals a.Id
                                         where spl.PlaylistId == pl.Id
                                         select new SongViewModel
                                         {
                                             Id = s.Id,
                                             Name = s.Name,
                                             Author = a.Name,
                                             FilePath = s.FilePath,
                                             CoverPath = s.CoverPath
                                         }).ToList()
                };
            return View(await res.ToListAsync());
        }


        public async Task<IActionResult> AddPlaylist(string playlistName)
        {
            var user = await db.User.FirstOrDefaultAsync(x => x.Email == User.Identity.Name);
            var pl = await db.Playlist.FirstOrDefaultAsync(x => x.Name == playlistName);
            if (pl==null)
            {
                var playlist = new Playlist
                {
                    Name = playlistName,
                    UserId = user.Id
                };
                db.Playlist.Add(playlist);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("PlayLists");
        }


        public async Task<IActionResult> DeletePlaylist(int id)
        {
            var pl = await db.Playlist.FirstOrDefaultAsync(x => x.Id == id);
            if (pl!=null)
            {
                db.Playlist.Remove(pl);
                var spl =await db.SongsPlaylist.Where(x => x.PlaylistId == id).ToListAsync();
                if (spl!=null)
                {
                    db.SongsPlaylist.RemoveRange(spl);
                }
                await db.SaveChangesAsync();
            }
            return RedirectToAction("PlayLists");
        }


        public async Task<IActionResult> DeleteMusicFromPlaylist(int songId, int playlistId)
        {
            var currentSong = db.SongsPlaylist.FirstOrDefault(c => c.SongId == songId && c.PlaylistId == playlistId);
            if (currentSong != null)
            {
                db.SongsPlaylist.Remove(currentSong);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("PlayLists");
        }
    }
    public class PlayListsViewModel
    {
        public List<SongViewModel> ListSongViewModel { get; set; }
        public Playlist Playlist { get; set; }
        public string Name { get; set; }
    }
}
