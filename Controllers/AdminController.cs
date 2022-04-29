using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Data;
using MusicPlayer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MusicPlayer.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db;
        IWebHostEnvironment ae;
        public AdminController(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            ae = appEnvironment;
        }

        public IActionResult AddPage()
        {
            ViewBag.authors = db.Author.Select(x => x.Name).ToList();
            ViewBag.genres = db.Genre.Select(x => x.Name).ToList();
            ViewBag.albums = db.Album.Select(x => x.Name).ToList();
            return View();
        }
        public IActionResult DeletePage()
        {
            ViewBag.authors = db.Author.Select(x => x.Name).ToList();
            ViewBag.genres = db.Genre.Select(x => x.Name).ToList();
            ViewBag.albums = db.Album.Select(x => x.Name).ToList();
            ViewBag.songs = db.Song.Select(x => x.Name).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(List<IFormFile> upload, string name, string author, string genre, string album)
        {
            string COVER = "";
            string FILE = "";

            var author_q = db.Author.FirstOrDefault(x => x.Name == author);
            var genre_q = db.Genre.FirstOrDefault(x => x.Name == genre);
            var album_q = db.Album.FirstOrDefault(x => x.Name == album);

            if (author_q == null) author_q = new Author { Name = author };
            if (genre_q == null) genre_q = new Genre { Name = genre };
            if (album_q == null) album_q = new Album { Name = album, Date = DateTime.Now};

            #region files upload
            foreach (var file in upload)
            {
                string fileName = Path.GetFileName(file.FileName);
                string path = "";
                if (fileName.Contains(".jpg") || fileName.Contains(".png"))
                {
                    COVER = fileName;
                    path = Path.Combine(this.ae.WebRootPath, "covers");
                }
                else if (fileName.Contains(".mp3"))
                {
                    FILE = fileName;
                    path = Path.Combine(this.ae.WebRootPath, "music");
                }
                else
                {
                    continue;
                }
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            #endregion

            var res = new Song
            {
                Name = name,
                CoverPath = "covers/" + COVER,
                FilePath = "music/" + FILE,
                Genre = genre_q,
                Author = author_q,
                Album = album_q
            };
            db.Song.Add(res);
            await db.SaveChangesAsync();

            return RedirectToAction("AddPage");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(string author, string album, string genre, string song)
        {
            var auth = db.Author.FirstOrDefault(x => x.Name == author);
            if (auth != null)
            {
                var al= db.Album.Include(s=>s.Songs).Where(x=>x.Songs.FirstOrDefault().Author.Name==author).ToList();
                db.Album.RemoveRange(al);
                db.Author.Remove(auth);
            }

            var alb = db.Album.FirstOrDefault(x => x.Name == album);
            if (alb != null)
                db.Album.Remove(alb);

            var gen = db.Genre.FirstOrDefault(x => x.Name == genre);
            if (gen != null)
                db.Genre.Remove(gen);

            var sng = db.Song.FirstOrDefault(x => x.Name == song);
            if (sng != null)
                db.Song.Remove(sng);


            await db.SaveChangesAsync();
            return RedirectToAction("DeletePage");
        }
    }
}
