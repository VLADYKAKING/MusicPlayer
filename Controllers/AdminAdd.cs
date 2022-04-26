using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MusicPlayer.Data;
using System.IO;
using System.Threading.Tasks;

namespace MusicPlayer.Controllers
{
    public class AdminAdd : Controller
    {
        private ApplicationDbContext db;
        IWebHostEnvironment ae;
        public AdminAdd(ApplicationDbContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            ae = appEnvironment;
        }

        public IActionResult AddPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(IFormFile upload)
        {
            string fileName = Path.GetFileName(upload.FileName);
            string path="";
            if (fileName.Contains(".jpg") || fileName.Contains(".png"))
            {
                path = Path.Combine(this.ae.WebRootPath, "covers");
            }
            else if (fileName.Contains(".mp3"))
            {
                path = Path.Combine(this.ae.WebRootPath, "music");
            }
            else
            {
                return RedirectToAction("AddPage");
            }
            
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            
            using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                upload.CopyTo(stream);
            }

            return RedirectToAction("AddPage");
        }
    }
}
