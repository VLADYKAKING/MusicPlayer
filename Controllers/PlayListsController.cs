using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicPlayer.Data;
namespace MusicPlayer.Controllers
{
    public class PlayListsController : Controller
    {
        private ApplicationDbContext db;
        public PlayListsController(ApplicationDbContext context)
        {
            db = context;
        }


        //playlists
        [Authorize(Roles = "admin, user")]
        public IActionResult PlayLists()
        {
            return View();
        }





    }
}
